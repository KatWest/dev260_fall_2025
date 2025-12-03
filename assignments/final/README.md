# Project Title

> An app simulating how a fantasy adventurer's guild might work.

---

## What I Built (Overview)

**Problem this solves:**  
_Explain the real-world task your app supports and why it's useful (2–4 sentences)._

**Your Answer:**
This app acts as an organizational tool for adventurer guild staff and members. Guild staff can use this app to add quests to the digital quest board, and add monsters from adventurer reports to the Monster Compendium. Adventurers can use this app to check the quest board for quests and review the Monster Compendium.

**Core features:**  
_List the main features your application provides (Add, Search, List, Update, Delete, etc.)_

**Your Answer:**

- QUESTS
- Add quests
- View all avalable quests
- Update quest data
- Indicate that a quest has been assigned
- Indicate that a quest has been completed
- MONSTER COMPENDIUM
- Add monster to the compendium
- View monster compendium
- Update monster data
- Delete monster data

## How to Run

**Requirements:**  
_List required .NET version, OS requirements, and any dependencies._

**Your Answer:**

```bash
git clone https://github.com/KatWest/dev260_fall_2025.git
cd final
dotnet build
```

**Run:**  
_Provide the command to run your application._

**Your Answer:**

```bash
dotnet run
```

**Sample data (if applicable):**  
_Describe where sample data lives and how to load it (e.g., JSON file path, CSV import)._

**Your Answer:**
The sample data should automatically load on program run. It is currently hard-coded in GuildSystemNavigator.cs

---

## Using the App (Quick Start)

**Typical workflow:**  
_Describe the typical user workflow in 2–4 steps._

**Your Answer:**

1. Start app
2. Choose menu choice
3. Follow prompts

**Input tips:**  
_Explain case sensitivity, required fields, and how common errors are handled gracefully._

**Your Answer:**
Navigation commands should be case-insensitive. Monster Dictionary keys are made lowercase.

---

## Data Structures (Brief Summary)

> Full rationale goes in **DESIGN.md**. Here, list only what you used and the feature it powers.

**Data structures used:**  
_List each data structure and briefly explain what feature it powers._

**Your Answer:**

- `Dictionary<...>` → Acts as Monster Compendium
- `List<...>` → Acts as Quest Board

---

## Manual Testing Summary

> No unit tests required. Show how you verified correctness with 3–5 test scenarios.

**Test scenarios:**  
_Describe each test scenario with steps and expected results._

**Your Answer:**

**Scenario 1: [Name]**

- Steps:
- Expected result:
- Actual result:

**Scenario 2: [Name]**

- Steps:
- Expected result:
- Actual result:

**Scenario 3: [Name]**

- Steps:
- Expected result:
- Actual result:

**Scenario 4: [Name] (optional)**

- Steps:
- Expected result:
- Actual result:

**Scenario 5: [Name] (optional)**

- Steps:
- Expected result:
- Actual result:

---

## Known Limitations

**Limitations and edge cases:**  
_Describe any edge cases not handled, performance caveats, or known issues._

**Your Answer:**

-
-

## Comparers & String Handling

**Keys comparer:**  
_Describe what string comparer you used (e.g., StringComparer.OrdinalIgnoreCase) and why._

**Your Answer:**

**Normalization:**  
_Explain how you normalize strings (trim whitespace, consistent casing, duplicate checks)._

**Your Answer:**

---

## Credits & AI Disclosure

**Resources:**  
_List any articles, documentation, or code snippets you referenced or adapted._

**Your Answer:**

-
- **AI usage (if any):**  
   _Describe what you asked AI tools, what code they influenced, and how you verified correctness._

  **Your Answer:**

  ***

## Challenges and Solutions

**Biggest challenge faced:**  
_Describe the most difficult part of the project - was it choosing the right data structures, implementing search functionality, handling edge cases, designing the user interface, or understanding a specific algorithm?_

**Your Answer:**

**How you solved it:**  
_Explain your solution approach and what helped you figure it out - research, consulting documentation, debugging with breakpoints, testing with simple examples, refactoring your design, etc._

**Your Answer:**

**Most confusing concept:**  
_What was hardest to understand about data structures, algorithm complexity, key comparers, normalization, or organizing your code architecture?_

**Your Answer:**

## Code Quality

**What you're most proud of in your implementation:**  
_Highlight the best aspect of your code - maybe your data structure choices, clean architecture, efficient algorithms, intuitive user interface, thorough error handling, or elegant solution to a complex problem._

**Your Answer:**

**What you would improve if you had more time:**  
_Identify areas for potential improvement - perhaps adding more features, optimizing performance, improving error handling, adding data persistence, refactoring for better maintainability, or enhancing the user experience._

**Your Answer:**

## Real-World Applications

**How this relates to real-world systems:**  
_Describe how your implementation connects to actual software systems - e.g., inventory management, customer databases, e-commerce platforms, social networks, task managers, or other applications in the industry._

**Your Answer:**

**What you learned about data structures and algorithms:**  
_What insights did you gain about choosing appropriate data structures, performance tradeoffs, Big-O complexity in practice, the importance of good key design, or how data structures enable specific features?_

**Your Answer:**

## Submission Checklist

- [x] Public GitHub repository link submitted
- [x] README.md completed (this file)
- [x] DESIGN.md completed
- [x] Source code included and builds successfully
- [ ] (Optional) Slide deck or 5–10 minute demo video link (unlisted)

**Demo Video Link (optional):**
