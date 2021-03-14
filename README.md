# SoJSON
SoJSON is a simple (perhaps too simple) .Net class library to parse SOAP string to JSON. Its my first repo so may not be my best work. The class method takes a SOAP string and returns JSON with only the attributes (namespaces are trimmed out).

## Why use SoJSON

Honestly, you really don't need to. But if you are like me who deals with integrations often and has to parse responses from web services that are still using SOAP to the more friendly JSON, then yeah, give it a shot.

## Usage

As this is an extension, simply call the method on the string you need converted, like so

```c#
string soapString = File.ReadAllText("SOAPData.txt");
string soapString = soapString.SOAPToJSON();
```

I know, I know.....lazy

## Dependencies

The class uses Newtosoft.Json @https://github.com/JamesNK/Newtonsoft.Json to perform the final serialization

