# FourRussiansMethod 
implementation of the Four Russian Method to speed up the multiplication of boolean matrices by C# 
 
For run application open .sln file in Visual Studio, and compile'n'run "four_russians", which is main build. 
 
Structure:

four_russians/ 

Program.cs - main method + some console output for representation of measures. 

Operations.cs - some operations with matrixes not related with Four Russian Algorithm (like casual multiplication). 

FourRussian.cs - some related methods and algorithm itself. 

 
four_russiansTest/ 

... simple tests for all methods created by VS libs, but writen by me.  

 
Some info about code: 

Tamanov Andrey 

Student of HSE BSE, 4 Course. 

Four Russians Algorithm Implementation 


// for matrix NxN, where N = 10, 50, ..., 2000. 

// measure processor ticks for computing. 

// expected result: 

// russian_mult(NxN) = casual_mult(NxN) / log(N). 

// 

// plus bonus, accidentally i found one condition in casual_mult operation, 

// which speed it up from N^3 to N^2 in best case and to N^3 in worst case (no spped up). 

// but in practice it acceleration closer to N^2. 

//  

// сompile, wait a minute and enjoy numbers :-) 

// (martixes build randomly, so you can restart process to get NEW time) 

