# Code generation

## Tools

There are number of tools you can use to generate client code from REST API specification. One of them is NSwagStudio

### NSwagStudio

You can download and find detailed documentation in [NSwagStudio web site](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio).

![NSwagStudio](Images/NSwagStudio.png)

You can adjust configured code to your needs. Some suggestions, are below.

#### NSwagStudio step-by-step code generation instructions

1. In *Input -> Specification URL:* enter REST API specification yaml, e.g.:
   *<https://sepaexpress-prod-fx.azurewebsites.net/openapi/services/v2/openapi.yaml>*
1. In *Input -> Runtime* select required .net version e.g.: *Net60*
1. In *Outputs* select *CSharp Client* checkbox
1. Set *Namespace* of for the generated classes (in our example it is *B4Payment.SEPAexpress.Client.Demo.ApiClient*)
1. You can adjust generated client class name (default is *Client*). It is better to use e.g. *SepaExpressApiClient*
1. In JSON Serialization section unselect *Required properties must be defined in JSON (set Required.Always when property is required)*
1. In settings check *Generate optional schema properties (not required as nullable properties)*
1. Press the big button *Generate Outputs*
1. In the *Output* window you can select generated code and paste it into you code
1. Because there is a bug in NSwagStudio you need to fix the generated code.    Instead of improper statement ```return default(void);``` you need to write proper statement: ```return;```.

You need to repeat steps above for Authorization API.

1. In *Input -> Specification URL:* enter REST API specification yaml, e.g.:
   *<https://sepaexpress-prod-fx.azurewebsites.net/openapi/identity/v1/openapi.yaml>*
1. In *Input -> Runtime* select required .net version e.g.: *Net60*
1. In *Outputs* select *CSharp Client* checkbox
1. Set *Namespace* of for the generated classes (in our example it is *B4Payment.SEPAexpress.Client.Demo.IdentityClient*)
1. You can adjust generated client class name (default is *Client*). It is better to use e.g. *SepaExpressIdentityApiClient*
1. In JSON Serialization section unselect *Required properties must be defined in JSON (set Required.Always when property is required)*
1. In settings check *Generate optional schema properties (not required as nullable properties)*
1. Press the big button *Generate Outputs*
1. In the *Output* window you can select generated code and paste it into you code
1. Because there is a bug in NSwagStudio you need to fix the generated code.    Instead of improper statement ```return default(void);``` you need to write proper statement: ```return;```.

NSwagStudio projects can be save on disk for future usage. Such projects are attached in code source directory.
