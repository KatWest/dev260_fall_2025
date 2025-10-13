using System;
using System.Collections.Generic;
using System.IO;

namespace Week3ArraysSorting
{
    /// <summary>
    /// Book Catalog implementation for Assignment 2 Part B
    /// Demonstrates recursive sorting and multi-dimensional indexing for fast lookups
    /// 
    /// Learning Focus:
    /// - Recursive sorting algorithms (QuickSort or MergeSort)
    /// - Multi-dimensional array indexing for performance
    /// - String normalization and binary search
    /// - File I/O and CLI interaction
    /// </summary>
    public class BookCatalog
    {
        #region Data Structures
        
        // Book storage arrays - parallel arrays that stay synchronized
        private string[] originalTitles;    // Original book titles for display
        private string[] normalizedTitles;  // Normalized titles for sorting/searching
        
        // Multi-dimensional index for O(1) lookup by first two letters (A-Z x A-Z = 26x26)
        private int[,] startIndex;  // Starting position for each letter pair in sorted array
        private int[,] endIndex;    // Ending position for each letter pair in sorted array
        private char[] chars;
        
        // Book count tracker
        private int bookCount;
        
        #endregion
        
        /// <summary>
        /// Constructor - Initialize the book catalog
        /// Sets up data structures for book storage and multi-dimensional indexing
        /// </summary>
        public BookCatalog()
        {
            // Initialize arrays (will be resized when books are loaded)
            originalTitles = Array.Empty<string>();
            normalizedTitles = Array.Empty<string>();
            
            // Initialize multi-dimensional index arrays (26x26 for A-Z x A-Z)
            startIndex = new int[26, 26];
            endIndex = new int[26, 26];

            // Initialize all index ranges as empty (-1 indicates no books for that letter pair)
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    startIndex[i, j] = -1;  // -1 means no books start with this letter pair
                    endIndex[i, j] = -1;    // -1 means no books end with this letter pair
                }
            }
            chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            
            // Reset book count
            bookCount = 0;
            
            Console.WriteLine("BookCatalog initialized - Ready to load books and build index");
        }
        
        /// <summary>
        /// Load books from file and build sorted index
        /// </summary>
        /// <param name="filePath">Path to books.txt file</param>
        public void LoadBooks(string filePath)
        {
            try
            {
                Console.WriteLine($"Loading books from: {filePath}");
                
                // Step 1 - Load books from file
                LoadBooksFromFile(filePath);
                
                // TODO: Step 2 - Sort using recursive algorithm
                SortBooksRecursively();
                
                // TODO: Step 3 - Build multi-dimensional index
                BuildMultiDimensionalIndex();
                
                Console.WriteLine($"Successfully loaded and indexed {bookCount} books.");
                Console.WriteLine("Index built for A-Z x A-Z (26x26) letter pairs.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading books: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Start interactive lookup session
        /// TODO: Implement the CLI loop
        /// </summary>
        public void StartLookupSession()
        {
            Console.Clear();
            Console.WriteLine("=== BOOK CATALOG LOOKUP (Part B) ===");
            Console.WriteLine();
            
            // TODO: Check if books are loaded
            if (bookCount == 0)
            {
                Console.WriteLine("No books loaded! Please load a book file first.");
                return;
            }
            
            DisplayLookupInstructions();
            
            // TODO: Implement lookup loop
            bool keepLooking = true;
            
            while (keepLooking)
            {
                Console.WriteLine();
                Console.Write("Enter a book title (or 'exit'): ");
                string? query = Console.ReadLine();
                
                // TODO: Handle exit condition
                if (string.IsNullOrEmpty(query) || query.ToLowerInvariant() == "exit")
                {
                    keepLooking = false;
                    continue;
                }
                
                // TODO: Perform lookup
                PerformLookup(query);
            }
            
            Console.WriteLine("Returning to main menu...");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Load book titles from text file
        /// </summary>
        /// <param name="filePath">Path to the books file</param>
        private void LoadBooksFromFile(string filePath)
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Book file not found: {filePath}");
            }
            
            Console.WriteLine($"Reading book titles from: {filePath}");
            
            try
            {
                // Read all lines from file
                string[] lines = File.ReadAllLines(filePath);
                
                // Filter out empty lines and whitespace-only lines
                var validLines = new List<string>();
                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine))
                    {
                        validLines.Add(trimmedLine);
                    }
                }
                
                // Initialize arrays with the correct size
                bookCount = validLines.Count;
                originalTitles = new string[bookCount];
                normalizedTitles = new string[bookCount];
                
                // Store both original and normalized versions
                for (int i = 0; i < bookCount; i++)
                {
                    originalTitles[i] = validLines[i]; // Keep original formatting for display
                    normalizedTitles[i] = NormalizeTitle(originalTitles[i]); // Normalized for sorting/indexing
                }
                
                Console.WriteLine($"Successfully loaded {bookCount} book titles.");
            }
            catch (IOException ex)
            {
                throw new IOException($"Error reading file '{filePath}': {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error loading books from '{filePath}': {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Normalize book title for consistent sorting and indexing
        /// </summary>
        /// <param name="title">Original book title</param>
        /// <returns>Normalized title for sorting/indexing</returns>
        private string NormalizeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return "";
            }
            
            // Step 1: Trim whitespace and convert to uppercase
            string normalized = title.Trim().ToUpperInvariant();
            
            // Step 2: Optional - Remove leading articles for better sorting
            // This helps group books by their main title rather than article
            string[] articles = { "THE ", "A ", "AN " };
            
            foreach (string article in articles)
            {
                if (normalized.StartsWith(article))
                {
                    normalized = normalized.Substring(article.Length).Trim();
                    break; // Only remove the first article found
                }
            }
            
            // Step 3: Handle edge case where title was only articles
            if (string.IsNullOrEmpty(normalized))
            {
                return title.Trim().ToUpperInvariant(); // Return original if normalization results in empty
            }
            
            return normalized;
        }

        /// <summary>
        /// Sort books using recursive algorithm (QuickSort OR MergeSort)
        /// TODO: Choose ONE recursive sorting algorithm to implement
        /// </summary>
        private void SortBooksRecursively()
        {
            // Console.WriteLine("TODO: Implement recursive sorting algorithm");
            // Console.WriteLine("Choose ONE to implement:");
            // // Console.WriteLine("1. QuickSort - Choose pivot strategy and document it");
            // Console.WriteLine("2. MergeSort - Implement recursive split/merge");
            // Console.WriteLine();
            // Console.WriteLine("Requirements:");
            // Console.WriteLine("- Must be YOUR recursive implementation");
            // Console.WriteLine("- Cannot use Array.Sort() or LINQ");
            // Console.WriteLine("- Sort both arrays in parallel (original and normalized)");
            // Console.WriteLine("- Document Big-O time/space complexity in README");

            // TODO: Call your chosen sorting algorithm
            // Example: QuickSort(normalizedTitles, originalTitles, 0, bookCount - 1);
            // Example: MergeSort(normalizedTitles, originalTitles, 0, bookCount - 1);

            MergeSort(normalizedTitles, originalTitles, 0, bookCount - 1);

            Console.WriteLine($"Successfully sorted {bookCount} book titles.");
            // Console.WriteLine("[{0}]", string.Join(", ", normalizedTitles));
            // Console.WriteLine("[{0}]", string.Join(", ", originalTitles));
        }

        /// <summary>
        /// Build multi-dimensional index over sorted data
        /// Create 26x26 index for first two letters
        /// this was v helpful: https://stackoverflow.com/questions/15941985/how-to-get-the-first-n-number-of-characters-from-a-string 
        /// </summary>
        private void BuildMultiDimensionalIndex()
        {

            foreach (string book in normalizedTitles)
            {
                char[] t = book.Take(2).ToArray();
                int bookIndex = Array.IndexOf(normalizedTitles, book);
                int char1Index = Array.IndexOf(chars, t[0]);
                int char2Index = Array.IndexOf(chars, t[1]);
                // Console.WriteLine("[{0}]", string.Join(", ", t));
                if (char1Index == -1) // if first char of title is not a letter
                {
                    if (char2Index == -1) // if second char of title is not a letter
                    {
                        if (startIndex[0, 0] == -1)         // if start index for char pairs has not been assigned
                            startIndex[0, 0] = bookIndex;   // assign it
                        endIndex[0, 0] = bookIndex;
                    }
                    else    // if second char of title is a letter
                    {
                        if (startIndex[0, char2Index] == -1)        // if start index for char pairs has not been assigned
                            startIndex[0, char2Index] = bookIndex;  // assign it
                        endIndex[0, char2Index] = bookIndex;
                    }
                }
                else    // if first char of title is NAN :D
                {
                    if (char2Index == -1) // protection for if second char of title is not a letter
                    {
                        if (startIndex[char1Index, 0] == -1)         // if start index for char pairs has not been assigned
                            startIndex[char1Index, 0] = bookIndex;   // assign it
                        endIndex[char1Index, 0] = bookIndex;
                        // startIndex[char1Index, 0] = bookIndex;
                    }
                    else    // if both first chars of title are NAN
                    {
                        if (startIndex[char1Index, char2Index] == -1)       // if start index for char pairs has not been assigned
                            startIndex[char1Index, char2Index] = bookIndex; // assign it
                        endIndex[char1Index, char2Index] = bookIndex;
                    }
                }
            }

            // Checking contents of startIndex and endIndex
            // for (int x0 = 0; x0 < startIndex.GetLength(0); x0++)
            // {
            //     for (int x1 = 0; x1 < startIndex.GetLength(1); x1++)
            //         Console.Write("{0}, ", startIndex[x0, x1]);
            //     Console.WriteLine();
            // }
            // for (int x0 = 0; x0 < endIndex.GetLength(0); x0++)
            // {
            //     for (int x1 = 0; x1 < endIndex.GetLength(1); x1++)
            //         Console.Write("{0}, ", endIndex[x0, x1]);
            //     Console.WriteLine();
            // }
        }
        
        /// <summary>
        /// Perform lookup with exact match and suggestions
        /// TODO: Implement indexed lookup with binary search
        /// </summary>
        /// <param name="query">User's search query</param>
        private void PerformLookup(string query)
        {
            // TODO: Normalize query same way as indexing
            string normalizedQuery = NormalizeTitle(query);
            char[] q = normalizedQuery.Take(2).ToArray();
            int char1Index = Array.IndexOf(chars, q[0]);
            int char2Index = Array.IndexOf(chars, q[1]);
            
            if (char1Index == -1)   // if first char of input is not a letter
                char1Index = 0;
            if (char2Index == -1)   // if second char of input is not a letter
                char2Index = 0;

            int bookSliceSize = endIndex[char1Index, char2Index] - startIndex[char1Index, char2Index] + 1;
            string[] booksNormed = new string[bookSliceSize];
            string[] books = new string[bookSliceSize];
            string foundBook = "";

            if (startIndex[char1Index, char2Index] > -1)
            {
                Array.Copy(normalizedTitles, startIndex[char1Index, char2Index], booksNormed, 0, bookSliceSize);
                Array.Copy(originalTitles, startIndex[char1Index, char2Index], books, 0, bookSliceSize);
                if (Array.BinarySearch(booksNormed, normalizedQuery) > -1)
                {
                    Console.WriteLine($"book found for {query}");
                    // Console.WriteLine(Array.BinarySearch(booksNormed, normalizedQuery));
                    foundBook = originalTitles[Array.BinarySearch(normalizedTitles, normalizedQuery)];
                    Console.WriteLine(foundBook);
                }
                else 
                    Console.WriteLine("[{0}]", string.Join(", ", books));
            }
            else
            {
                Console.WriteLine("No match. Suggestions (TODO): ");
                
            }

            // Console.WriteLine("[{0}]", string.Join(", ", books));
            // Console.WriteLine(foundBook);
            
            
            // Console.WriteLine($"TODO: Perform lookup for '{query}'");
            // Console.WriteLine("Requirements:");
            // Console.WriteLine("1. Get first 1-2 letters of normalized query");
            // Console.WriteLine("2. Look up [start,end) range from 2D index in O(1)");
            // Console.WriteLine("3. If empty range, show suggestions from nearby ranges");
            // Console.WriteLine("4. If non-empty range, binary search within slice");
            // Console.WriteLine("5. Show exact match or helpful suggestions");
            // Console.WriteLine("6. Always display original titles (not normalized)");
            
            // TODO: Extract first two letters for indexing
            // TODO: Get start/end range from 2D index
            // TODO: If range is empty, find suggestions
            // TODO: If range exists, binary search for exact match
            // TODO: Display results using original titles
        }
        
        /// <summary>
        /// Display lookup instructions
        /// TODO: Customize instructions for your implementation
        /// </summary>
        private void DisplayLookupInstructions()
        {
            Console.WriteLine("BOOK LOOKUP INSTRUCTIONS:");
            Console.WriteLine("- Enter any book title to search");
            Console.WriteLine("- Exact matches will be shown if found");
            Console.WriteLine("- Suggestions provided for partial/no matches");
            Console.WriteLine("- Type 'exit' to return to main menu");
            Console.WriteLine();
            Console.WriteLine($"Catalog contains {bookCount} books, sorted and indexed for fast lookup.");
        }

        // TODO: Add your sorting algorithm methods
        // Choose ONE to implement:

        /// <summary>
        /// QuickSort implementation (Option 1)
        /// TODO: Implement if you choose QuickSort
        /// </summary>
        // private void QuickSort(string[] normalizedArray, string[] originalArray, int low, int high)
        // {
        //     // TODO: Implement recursive QuickSort
        //     // TODO: Choose and document pivot strategy
        //     // TODO: Ensure both arrays stay synchronized
        // }

        /// <summary>
        /// MergeSort implementation (Option 2)  
        /// TODO: Implement if you choose MergeSort
        /// </summary>
        private void MergeSort(string[] normalizedArray, string[] originalArray, int left, int right)
        {
            // TODO: Implement recursive MergeSort
            // TODO: Handle O(n) extra space requirement
            // TODO: Ensure both arrays stay synchronized
            // Console.WriteLine("[{0}]", string.Join(", ", normalizedArray));
            // Console.WriteLine("[{0}]", string.Join(", ", originalArray));

            if (left < right)
            {
                int m = left + (right - left) / 2;
                MergeSort(normalizedArray, originalArray, left, m);
                MergeSort(normalizedArray, originalArray, m + 1, right);

                // MergeArrays(normalizedArray, left, m, right);
                // MergeArrays(originalArray, left, m, right);
                MergeArrays(normalizedArray, originalArray, left, m, right);
            }

            // checking to make sure that the arrays got sorted correctly
            // Console.WriteLine("[{0}]", string.Join(", ", normalizedArray));
            // Console.WriteLine("[{0}]", string.Join(", ", originalArray));
        }

        // TODO: Add helper methods as needed
        // Examples:
        // - GetLetterIndex(char letter) - Convert A-Z to 0-25
        // - BinarySearchInRange(string query, int start, int end)
        // - FindSuggestions(string query, int maxSuggestions)
        // - SwapElements(int index1, int index2) - For QuickSort
        // - MergeArrays(...) - For MergeSort

        /// <summary>
        /// overload for MergeArrays(string[] normArray, string[] origArray, int l, int m, int r)
        /// in case there's a need to mergesort a single array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="r"></param>
        private void MergeArrays(string[] a, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            string[] L = new string[n1];
            string[] R = new string[n2];
            int i, j;

            for (i = 0; i < n1; i++)
                L[i] = a[l + i];
            for (j = 0; j < n2; j++)
                R[j] = a[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (string.Compare(L[i], R[j]) < 0)
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                a[k] = L[i];
                i++; k++;
            }
            while (j < n2)
            {
                a[k] = R[j];
                j++; k++;
            }
        }
        
        /// <summary>
        /// this g4g article was v helpful for this: https://www.geeksforgeeks.org/dsa/merge-sort/ 
        /// </summary>
        /// <param name="normArray"></param>
        /// <param name="origArray"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="r"></param>
        private void MergeArrays(string[] normArray, string[] origArray, int l, int m, int r)
        {
            int n1 = m - l + 1; int n2 = r - m;

            string[] L = new string[n1]; string[] LO = new string[n1];
            string[] R = new string[n2]; string[] RO = new string[n2];
            int i, j;
            
            for (i = 0; i < n1; i++) {
                L[i] = normArray[l + i];
                LO[i] = origArray[l + i]; }
            for (j = 0; j < n2; j++) {
                R[j] = normArray[m + 1 + j];
                RO[j] = origArray[m + 1 + j]; }
            
            i = 0;
            j = 0;

            int k = l;

            while (i < n1 && j < n2)
            {
                if (string.Compare(L[i], R[j]) < 0) {
                    normArray[k] = L[i];
                    origArray[k] = LO[i];
                    i++; }
                else {
                    normArray[k] = R[j];
                    origArray[k] = RO[j];
                    j++; }
                k++;
            }
            while (i < n1) {
                normArray[k] = L[i];
                origArray[k] = LO[i];
                i++; k++; }
            while (j < n2) {
                normArray[k] = R[j];
                origArray[k] = RO[j];
                j++; k++; }
        }
    }
}