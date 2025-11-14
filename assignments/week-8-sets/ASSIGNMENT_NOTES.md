# Assignment 8: Spell Checker & Vocabulary Explorer - Implementation Notes

**Name:** Katherine West

## HashSet Pattern Understanding

**How HashSet<T> operations work for spell checking:**
By checking if a string exists within a HashSet designated as a dictionary, the string can be assumed to be spelled correctly.

However, that is assuming that the string within the dictionary is also spelled correctly. Additionally, words that have participles are not considered as correct unless they are added to the dictionary.

## Challenges and Solutions

**Biggest challenge faced:**
Probably the hardest part for me was the file I/O handling. Mainly because I did not initally clock that the file name would be passed in with the file extension. I struggled with the program not reading the file until I added a line to print the exact file name that was passed in.

**How you solved it:**
Added a line to print the exact file name that was passed in.

**Most confusing concept:**
No concepts were confusing

## Code Quality

**What you're most proud of in your implementation:**
BEGONE CURLY BRACKETS AROUND SINGLE LINES OF CODE!! 🧙🏼‍♂️
Also, chaining OrderBy, Take, and ToList for the return statements for GetMisspelledWords and GetUniqueWordsSample

**What you would improve if you had more time:**
Add more words to the dictionary. Maybe use an online dictionary api to get all the words in like the Merriam-Webster dictionary.

## Testing Approach

**How you tested your implementation:**
Ran the program and clicked buttons.

**Test scenarios you used:**
[List specific scenarios you tested, like mixed case words, punctuation handling, edge cases, etc.]

**Issues you discovered during testing:**
no issues

## HashSet vs List Understanding

**When to use HashSet:**
When I need to just have a bucket of data and do not need it to be sorted in any way.

**When to use List:**
When I need the data in a spacific order.

**Performance benefits observed:**
[Describe how O(1) lookups and automatic uniqueness helped your implementation]

## Real-World Applications

**How this relates to actual spell checkers:**
[Describe how your implementation connects to tools like Microsoft Word, Google Docs, etc.]

**What you learned about text processing:**
[What insights did you gain about handling real-world text data and normalization?]

## Stretch Features
None implemented

## Time Spent

**Total time:** 7 hr

**Breakdown:**
- Understanding HashSet concepts and assignment requirements: 0.5 hr
- Implementing the 6 core methods: 4 hr
- Testing different text files and scenarios: 1 hr
- Debugging and fixing issues: 1 hr
- Writing these notes: 0.5 hr

**Most time-consuming part:** Coding

## Key Learning Outcomes

**HashSet concepts learned:**
[What did you learn about O(1) performance, automatic uniqueness, and set-based operations?]

**Text processing insights:**
[What did you learn about normalization, tokenization, and handling real-world text data?]

**Software engineering practices:**
[What did you learn about error handling, user interfaces, and defensive programming?]