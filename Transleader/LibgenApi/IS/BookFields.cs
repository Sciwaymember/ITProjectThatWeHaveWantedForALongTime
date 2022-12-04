
namespace LibgenApi.IS
{
    public enum BookFields
    {
        /// <summary>
        /// the LibGen ID
        /// </summary>
        id,
        /// <summary>
        /// – the title of the text  
        /// </summary>
        title, 
        /// <summary>
        /// – the volume number, if the text is part of a multi-volume series
        /// </summary>
        volumeinfo, 
        /// <summary>
        /// – the series that the text is part of
        /// </summary>
        series, 
        /// <summary>
        /// – the publication date of the text
        /// </summary>
        periodical,
        /// <summary>
        /// – the author of the text
        /// </summary>
        author, 
        year, 
        /// <summary>
        /// – the edition of the text
        /// </summary>
        edition, 
        /// <summary>
        /// – the publisher of the text
        /// </summary>
        publisher, 
        /// <summary>
        /// – the location of the publisher
        /// </summary>
        city, 
        /// <summary>
        /// – the number of pages in the text
        /// </summary>
        pages, 
        /// <summary>
        /// – the language of the text
        /// </summary>
        language, 
        /// <summary>
        /// – A number corresponding to the topic of the text; for example, 130 is "Mathematics/Logic"
        /// </summary>
        topic, 
        library,
        issue,
        /// <summary>
        /// – the text's short and long International Standard Book Numbers (not necessarily in that order)
        /// </summary>
        identifier, 
        /// <summary>
        /// – the text's International Standard Serial Number
        /// </summary>
        issn, 
        /// <summary>
        /// – the text's Amazon Standard Identification Number
        /// </summary>
        asin, 
        /// <summary>
        /// – the text's Universal Decimal Classification number
        /// </summary>
        udc, 
        lbc,
        /// <summary>
        /// – the text's Dewey Decimal Classification number
        /// </summary>
        ddc, 
        /// <summary>
        /// – the text's Library of Congress Classification number
        /// </summary>
        lcc, 
        /// <summary>
        /// – the file's Digital Object Identifier
        /// </summary>
        doi, 
        /// <summary>
        /// – the text's Google Books ID
        /// </summary>
        googlebookid, 
        /// <summary>
        /// – the text's Open Library ID
        /// </summary>
        openlibraryid, 
        commentary,
        dpi,
        color,
        cleaned,
        orientation,
        /// <summary>
        /// – the text is paginated (1) or not (0)
        /// </summary>
        paginated, 
        /// <summary>
        /// – the text is scanned from a physical copy (1) or not (0)
        /// </summary>
        scanned, 
        /// <summary>
        /// – the text has bookmarks (1) or not (0)
        /// </summary>
        bookmarked, 
        /// <summary>
        /// – the text is searchable (1) or not (0)
        /// </summary>
        searchable, 
        /// <summary>
        /// – the size of the file in bytes
        /// </summary>
        filesize, 
        /// <summary>
        /// – the extension of the file (.pdf, .epub, .mobi, etc.)
        /// </summary>
        extension, 
        /// <summary>
        /// – the [MD5](http://www.md5.net) hash of the file
        /// </summary>
        md5, 
        /// <summary>
        /// – the file's CRC32 checksum
        /// </summary>
        crc32, 
        /// <summary>
        /// – the file's eDonkey hash
        /// </summary>
        edonkey, 
        /// <summary>
        /// – the text's eMule file hash
        /// </summary>
        aich, 
        /// <summary>
        /// – the file's SHA-1 hash
        /// </summary>
        sha1, 
        /// <summary>
        /// – the file's Tiger tree hash
        /// </summary>
        tth, 
        generic,
        /// <summary>
        /// – the name of the file in the LibGen database, in the form directory/md5. The directory name is the text's LibGen ID rounded to the nearest thousand, and the MD5 hash is in lowercase. (The directory that each file is located in is also included in the file name.)
        /// </summary>
        filename, 
        visible,
        /// <summary>
        /// – As far as I can tell, this is the file path of the original file on the machine of whoever uploaded it.
        /// </summary>
        locator, 
        local,
        /// <summary>
        /// – the date/time when the text was added to the database, formatted as YYYY-MM-DD HH:MM:SS
        /// </summary>
        timeadded, 
        /// <summary>
        /// - the date/time when the text's entry in the database was edited, formatted as YYYY-MM-DD HH:MM:SS
        /// </summary>
        timelastmodified, 
        /// <summary>
        /// – the path to the cover image for the text: the filename followed by a lowercase letter (there's a function to determine the letter for each cover, but I don't know enough PHP to understand it).
        /// </summary>
        coverurl,
        descr,
    }
}
