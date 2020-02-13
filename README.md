# UnixTimeMilliseconds.JsonConversion
Custom converter for JSON.Net that handles millisecond-based Unix timestamps.

While JSON.Net already has a converter for serializing/deserializing regular Unix timestamps out of the box, that only handles second-based timestamps. This project adds converters that understand millisecond-based timestamps.


## Usage
### Deserialization
```csharp
var input = "1519318716745";
var rslt = JsonConvert.DeserializeObject<DateTime>(input, new UnixTimeMillisecondsConverter());
//The deserialized result will be outputted in your local time. For example, in EST, the result would be Feb 2, 1018, 11:58:36.745 AM EST/
```

### Serialization
```csharp
var input = new DateTime(2018, 2, 22, 11, 58, 36, 745)
var rslt = JsonConvert.SerializeObject(input, new UnixTimeMillisecondsConverter());
//When being serialized, the result will be converted to UTC. So, if your timezone was EST, the output would be 1519318716745.
```
