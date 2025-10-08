Note: I heavily referenced the Big-O notaion and complexity article

Structure 	        Operation 	                Big-O (Avg)     One-sentence rationale
Array 	            Access by index 		    O(1)            direct addressing by index
Array 	            Search (unsorted) 		    O(n)            need to visit all elements once
List<T> 	        Add at end 		            O(1) amortized  resizes occasionally but average per add is constant
List<T> 	        Insert at index 		    O(n)            need to shift tail ements to make room or close gaps
Stack<T> 	        Push / Pop / Peek 		    O(1)            operate at one end
Queue<T> 	        Enqueue / Dequeue / Peek 	O(1)            operate at one end
Dictionary<K,V> 	Add / Lookup / Remove 		O(1)/O(n)       hashing to buckets
HashSet<T> 	        Add / Contains / Remove 	O(1)            like dictionary