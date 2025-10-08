First thought conclusion: My machine, despite being nearly 10 years old, is quite speedy. However, that may be in part due to recently swapping from a Windows 10 OS to a Kubuntu (linux) OS.

Looking at my measured benchmark data over three tests I would say that the results do clearly reflect Big-O expectations.
I am surprised by how the N=1000 tests for List.Contains(N-1) and HashSet.Contains are for the most part around 0.4 ms, compared to almost every other test that seems to generally not even reach 0.1 ms. Based on the fact that the two tests are the first ones, I am going to assume that the reason is due to the program 'warming up' so to speak.
Given a large dataset and many membership checks, I think I would choose to use either a Dictonary or a HashSet.

== BENCHMARK DATA ==
Test 1
N=1000
List.Contains(N-1): 0.4712 ms
HashSet.Contains: 0.3977 ms
Dict.ContainsKey: 0.008 ms
List.Contains(-1): 0.0054 ms
HashSet.Contains (-1): 0.0003 ms
Dict.ContainsKey (-1): 0.0011 ms

N=10000
List.Contains(N-1): 0.0018 ms
HashSet.Contains: 0.0001 ms
Dict.ContainsKey: 0 ms
List.Contains(-1): 0.0014 ms
HashSet.Contains (-1): 0 ms
Dict.ContainsKey (-1): 0 ms

N=100000
List.Contains(N-1): 0.033 ms
HashSet.Contains: 0.0006 ms
Dict.ContainsKey: 0.0003 ms
List.Contains(-1): 0.0222 ms
HashSet.Contains (-1): 0.0003 ms
Dict.ContainsKey (-1): 0.0001 ms

N=250000
List.Contains(N-1): 0.0804 ms
HashSet.Contains: 0.0004 ms
Dict.ContainsKey: 0.0003 ms
List.Contains(-1): 0.0894 ms
HashSet.Contains (-1): 0.0007 ms
Dict.ContainsKey (-1): 0.0003 ms


Test 2
N=1000
List.Contains(N-1): 0.3537 ms
HashSet.Contains: 0.5061 ms
Dict.ContainsKey: 0.0095 ms
List.Contains(-1): 0.0055 ms
HashSet.Contains (-1): 0.0007 ms
Dict.ContainsKey (-1): 0.0014 ms

N=10000
List.Contains(N-1): 0.0025 ms
HashSet.Contains: 0.0002 ms
Dict.ContainsKey: 0.0002 ms
List.Contains(-1): 0.0023 ms
HashSet.Contains (-1): 0.0002 ms
Dict.ContainsKey (-1): 0.0002 ms

N=100000
List.Contains(N-1): 0.0262 ms
HashSet.Contains: 0.0002 ms
Dict.ContainsKey: 0.0003 ms
List.Contains(-1): 0.017 ms
HashSet.Contains (-1): 0.0001 ms
Dict.ContainsKey (-1): 0.0001 ms

N=250000
List.Contains(N-1): 0.0807 ms
HashSet.Contains: 0.0005 ms
Dict.ContainsKey: 0.0003 ms
List.Contains(-1): 0.0735 ms
HashSet.Contains (-1): 0.0004 ms
Dict.ContainsKey (-1): 0.0001 ms


Test 3
N=1000
List.Contains(N-1): 0.3989 ms
HashSet.Contains: 0.4071 ms
Dict.ContainsKey: 0.0075 ms
List.Contains(-1): 0.0054 ms
HashSet.Contains (-1): 0.0003 ms
Dict.ContainsKey (-1): 0.0008 ms

N=10000
List.Contains(N-1): 0.0024 ms
HashSet.Contains: 0.0001 ms
Dict.ContainsKey: 0.0001 ms
List.Contains(-1): 0.0016 ms
HashSet.Contains (-1): 0.0001 ms
Dict.ContainsKey (-1): 0.0001 ms

N=100000
List.Contains(N-1): 0.0276 ms
HashSet.Contains: 0.0003 ms
Dict.ContainsKey: 0.0004 ms
List.Contains(-1): 0.0202 ms
HashSet.Contains (-1): 0.0002 ms
Dict.ContainsKey (-1): 0.0001 ms

N=250000
List.Contains(N-1): 0.0872 ms
HashSet.Contains: 0.0004 ms
Dict.ContainsKey: 0.0002 ms
List.Contains(-1): 0.0814 ms
HashSet.Contains (-1): 0.0004 ms
Dict.ContainsKey (-1): 0.0002 ms