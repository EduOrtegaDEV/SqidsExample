# Sqids library example project using .net 8.

Sqids is a lightweight, open-source library that generates short, unique, and human-readable IDs from arbitrary data. Its primary goal is to provide a simple and efficient way to generate and encode unique IDs for use in various applications.

Sqids library offers a fascinating solution to a common programming challenge: converting numerical identifiers into short, unique strings. Whether you're working on URL shortening, database sharding, or any scenario where you need to obscure IDs without sacrificing uniqueness, Hashids steps in as a handy tool. Let's delve into its intricacies!  

```
//You can convert this:
var id = 10;
//To this:
var encodedId = squids.Encode(id);
//Outputs YpEmh
```
  
More info at: https://sqids.org/
Example at: https://github.com/EduOrtegaDEV/SqidsExample