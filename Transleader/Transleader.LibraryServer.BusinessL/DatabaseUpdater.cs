using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection.Metadata;
using Transleader.LibraryServer.BusinessL.ConsoleDiagnostics;
using Transleader.LibraryServer.BusinessL.Settings.DbUpdater;
using Transleader.LibraryServer.DataAccessL;
using Transleader.LibraryServer.DataAccessL.Extensions;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.BusinessL
{
    public class DatabaseUpdater : IDisposable
    {
        private static readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private readonly LibgenContext _lg;

        private readonly BookDbContext _db;

        private DateTime _timeLastAdded;

        private DateTime? _bookTimeLastAdded = null;

        private int _elementsAdded;

        private ProgressValueFigure[] _progresses;

        private bool disposedValue;

        private DbUpdaterConfig _options;

        public DatabaseUpdater(
            DbUpdaterConfig options,
            string? dbConnectionString = null)
        {
            _options = options;
            _lg = new LibgenContext();
            _db = new BookDbContext(dbConnectionString);
            _progresses = new ProgressValueFigure[3];
        }

        public Task canselTask => Task.Run(() =>
        {
            Thread.Sleep(1000);

            Console.WriteLine("Press the ESCAPE key to cancel...");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Press the ESCAPE key to cancel...");
            }

            Console.WriteLine("\nCancelling updating...\n");

           _cts.Cancel();
        });

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update begins:");

            _timeLastAdded = Convert.ToDateTime(_options.LaunchOptions.TimeLastAdded);
            DateTime timefinish = DateTime.Now;
            DateTime timefirst = _timeLastAdded;
            DateTime timelast = timefirst;

            _elementsAdded = 0;

            StartProgressStats(timelast);

            while (timelast != timefinish)
            {
                timefirst = _timeLastAdded.AddDays(1);
                timelast = timefirst;

                if (timelast > timefinish)
                {
                    timelast = timefinish;
                }

                await NewBooksInDateAreaAdd(timefirst, timelast, 1000);

                _timeLastAdded = timelast;

                Thread.Sleep(1000);
            }
        }

        private async Task NewBooksInDateAreaAdd(DateTime timefirst, DateTime timelast, int limit)
        {
            IEnumerable<BookLg>? booksLg = null;
            int limit1 = 0;
            int limit2 = limit;

            _progresses[0].Value = timelast.ToString();
            UpdateProgressStats();

            while (!booksLg.IsNullOrEmpty() || limit1 == 0)
            {
                try
                {
                    booksLg = await _lg.GetBooksLastAddedAsync(
                        timefirst, timelast, limit1: limit1, limit2, token: _cts.Token);

                    limit1 += 1000;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Trying again...");
                }

                if (booksLg != null)
                {
                    List<BookCompact> books =
                        booksLg
                        .Select(bookLg => bookLg.ToCompact())
                        .ToList();

                    _db.BooksCompact.AddRange(books);
                    try
                    {
                        await SaveAsync(_cts.Token);
                        _elementsAdded += books.Count;
                        _bookTimeLastAdded = booksLg.Last().Timeadded;
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Updating books...");
                        _db.BooksCompact.UpdateRange(books);
                    }
                }

                _progresses[1].Value = _elementsAdded.ToString();
                _progresses[2].Value = _bookTimeLastAdded.ToString();

                UpdateProgressStats();
            }
        }

        private void StartProgressStats(DateTime queryTimeArea)
        {
            _progresses[0] = new ProgressValueFigure(
                "Time area", queryTimeArea.ToString(), Console.GetCursorPosition(), 15);
            _progresses[1] = new ProgressValueFigure(
                "Elements added", _elementsAdded.ToString(), Console.GetCursorPosition(), 10);
            _progresses[2] = new ProgressValueFigure(
                "Time last added book", _bookTimeLastAdded.ToString(), Console.GetCursorPosition(), 15);
        }

        private void UpdateProgressStats()
        {
            foreach(var progress in _progresses)
            {
                progress.DrawValue();
            }
        }

        private async Task<int> SaveAsync(CancellationToken token)
        {
            return await _db.SaveChangesAsync(token);
        }

        private void UpdateOptions()
        {
            _options.LaunchOptions.TimeLastAdded = _timeLastAdded.ToString();
            _options.LaunchOptions.TimeNewer = _bookTimeLastAdded.ToString();
            _options.ReloadFile();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UpdateOptions();
                    _db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DatabaseUpdater()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
