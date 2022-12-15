using LibgenApi.IS;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Transleader.LibraryServer.DataAccessL.Models;

namespace Transleader.LibraryServer.DataAccessL
{
    public class LibgenContext
    {
        private BookController _controller;

        public LibgenContext()
        {
            _controller = new BookController();
        }

        /// <summary>
        /// Getting Book from libgen api by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="BookLg"/> instance or null if libgen db haven't book with this id</returns>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="JsonSerializationException"></exception>
        public async Task<BookLg?> GetBookAsync(int id)
        {
            using var response = await _controller.FindByIdAsync(
                ids: new int[]
                {
                    id
                },
                fields: new BookFields[]
                {
                    BookFields.id,
                    BookFields.identifier,
                    BookFields.title,
                    BookFields.author,
                    BookFields.descr,
                    BookFields.year,
                    BookFields.edition,
                    BookFields.extension,
                    BookFields.md5,
                    BookFields.coverurl,
                    BookFields.language,
                    BookFields.pages,
                    BookFields.timeadded,
                    BookFields.timelastmodified
                }
                );
            {

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(ex.Message);
                }

                BookLg? bookLb = null;
                string json = await response.Content.ReadAsStringAsync();

                if (!json.IsNullOrEmpty() && json != "[]")
                {
                    try
                    {
                        BookLg[]? bookLbs = JsonConvert.DeserializeObject<BookLg[]>(json);

                        if (bookLbs != null)
                        {
                            bookLb = bookLbs.FirstOrDefault();
                        }
                    }
                    catch
                    {
                        throw new JsonSerializationException();
                    }
                }

                return bookLb;
            }
        }

        /// <summary>
        /// Getting an array of books from libgen api by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="IEnumerable<>" /> <see cref="BookLg"/> instance or null if libgen db haven't books with this ids</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<IEnumerable<BookLg>?> GetBooksAsync(int[] ids)
        {
            using var response = await _controller.FindByIdAsync(
                ids: ids,
                fields: new BookFields[]
                {
                    BookFields.id,
                    BookFields.identifier,
                    BookFields.title,
                    BookFields.author,
                    BookFields.year,
                    BookFields.edition,
                    BookFields.extension,
                    BookFields.md5,
                    BookFields.coverurl,
                    BookFields.language,
                    BookFields.pages,
                    BookFields.timeadded,
                    BookFields.timelastmodified
                }
                );
            {

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(ex.Message);
                }

                string json = await response.Content.ReadAsStringAsync();

                BookLg[]? bookLbs = null;

                if (!json.IsNullOrEmpty() && json != "[]")
                {
                    try
                    {
                        bookLbs = JsonConvert.DeserializeObject<BookLg[]>(json);
                    }
                    catch
                    {
                        throw new JsonSerializationException();
                    }
                }

                return bookLbs;
            }
        }

        /// <summary>
        /// Getting an array of books from libgen api by time last added mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="IEnumerable<>" /> <see cref="BookLg"/> instance or null if libgen db haven't books with this area</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<IEnumerable<BookLg>?> GetBooksLastAddedAsync(
            DateTime timefirst, DateTime? timelast = null, 
            int? limit1 = null, int? limit2 = null, CancellationToken token = default)
        {
            using var response = await _controller.GetDateAreaAsync(
                mode: DateMode.last,
                timefirst: timefirst,
                timelast: timelast,
                limit1: limit1,
                limit2: limit2,
                fields: new BookFields[]
                {
                    BookFields.id,
                    BookFields.title,
                    BookFields.author,
                    BookFields.coverurl,
                    BookFields.timeadded,
                    BookFields.timelastmodified
                }
                );
            {

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(ex.Message);
                }

                string json = await response.Content.ReadAsStringAsync();

                BookLg[]? bookLbs = null;

                if (!json.IsNullOrEmpty() && json != "[]")
                {
                    try
                    {
                        bookLbs = JsonConvert.DeserializeObject<BookLg[]>(json);
                    }
                    catch
                    {
                        throw new JsonSerializationException();
                    }
                }

                response.Dispose();

                return bookLbs;
            }
        }

        /// <summary>
        /// Getting an array of books from libgen api by time last modified mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="IEnumerable<>" /> <see cref="BookLg"/> instance or null if libgen db haven't books with this area</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<IEnumerable<BookLg>?> GetBooksLastModifiedAsync(
           DateTime timefirst, DateTime? timelast = null,
           int? limit1 = null, int? limit2 = null)
        {
            using var response = await _controller.GetDateAreaAsync(
                mode: DateMode.modified,
                timefirst: timefirst,
                timelast: timelast,
                limit1: limit1,
                limit2: limit2,
                fields: new BookFields[]
                {
                    BookFields.id,
                    BookFields.identifier,
                    BookFields.title,
                    BookFields.author,
                    BookFields.year,
                    BookFields.edition,
                    BookFields.extension,
                    BookFields.md5,
                    BookFields.coverurl,
                    BookFields.language,
                    BookFields.pages,
                    BookFields.timeadded,
                    BookFields.timelastmodified
                }
                );
            {

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(ex.Message);
                }

                string json = await response.Content.ReadAsStringAsync();

                BookLg[]? bookLbs = null;

                if (!json.IsNullOrEmpty() && json != "[]")
                {
                    try
                    {
                        bookLbs = JsonConvert.DeserializeObject<BookLg[]>(json);
                    }
                    catch
                    {
                        throw new JsonSerializationException();
                    }
                }

                return bookLbs;
            }
        }

        /// <summary>
        /// Getting an array of books from libgen api by time newer mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="IEnumerable<>" /> <see cref="BookLg"/> instance or null if libgen db haven't books with this area</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<IEnumerable<BookLg>?> GetBooksNewerAsync(
            DateTime timenewer, int idnewer = 0,
            int? limit1 = null, int? limit2 = null, CancellationToken token = default)
        {
            using var response = await _controller.GetNewerAreaAsync(
               timenewer: timenewer,
               idnewer: idnewer,
               limit1: limit1,
               limit2: limit2,
               fields: new BookFields[]
               {
                    BookFields.id,
                    BookFields.title,
                    BookFields.author,
                    BookFields.coverurl,
                    BookFields.timeadded,
                    BookFields.timelastmodified
               },
               token: token
               );
            {

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new HttpRequestException(ex.Message);
                }

                string json = await response.Content.ReadAsStringAsync();

                BookLg[]? bookLbs = null;

                if (!json.IsNullOrEmpty() && json != "[]")
                {
                    try
                    {
                        bookLbs = JsonConvert.DeserializeObject<BookLg[]>(json);
                    }
                    catch
                    {
                        throw new JsonSerializationException();
                    }
                }

                return bookLbs;
            }         
        }
    }
}
