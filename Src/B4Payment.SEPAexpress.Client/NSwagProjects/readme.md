# sepaExpress .net client library

There are generated client classes in folders **Apia** and **Identity**.
The code is generate by NSwagStudio. NSwagProjects files are attached to the solution.

After generating the code it is necessary to fix generated code. 
Because there is a bug in NSwagStudio you need to fix the generated code.
Instead of improper statement ```return default(void);``` you need to write proper statement: ```return;```.

