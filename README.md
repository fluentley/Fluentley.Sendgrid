

# Fluentley.Sendgrid
[![CodeFactor](https://www.codefactor.io/repository/github/fluentley/fluentley.sendgrid/badge)](https://www.codefactor.io/repository/github/fluentley/fluentley.sendgrid)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/e64e4a9eb50a4467a0def1d53aadef0c)](https://www.codacy.com/project/emre_3/Fluentley.SendGrid/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=fluentley/Fluentley.SendGrid&amp;utm_campaign=Badge_Grade_Dashboard)
[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/Fluentley.SendGrid/)

Allows you to write code that is humanly readable.

Fluentley.Sendgird Fluently approach on Sendgrid Api
Sendgrid has a feature rich api and it may get pretty complicated while utilizing it. 
## Installation 
[Fluentley.SendGrid is avaliable on NuGet.](https://www.nuget.org/packages/Fluentley.SendGrid/)

Open the package console and Type:

`PM> Install Fluentley.Sendgrid`

## Quick Start
Let's start with sending a simple email.
```cs
using System.Threading.Tasks;
using Fluentley.SendGrid;

namespace SendGridSampleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //You may either initialize it as below or inject it via dependency injection.
            var sendGridService = new SendGridService("{YourSendGridKey}");

            //We are ready to send our first email.
            var result = await sendGridService.SendEmail(option => option
                .From("johnDoe@email.com")
                .Subject("Test Email From Fluentley.SendGrid")
                .AddContent(content => content
                    .Value("Hello World")
                    .Type("text/plain"))
                .AddRecipient(recipientOption => recipientOption
                    .AddTo("emre@fluentley.com"))
            ).Execute();
            //Notice the Execute() We have different options, so before execution it is just building your command.
        }
    }
}
```

Fluentley.SendGrid follows CQRS pattern and so each command is re-executable.

Execution of above code will give you back result as follows;
![Send Email Result](https://github.com/fluentley/Fluentley.Sendgrid/blob/master/ReadMeFiles/SendEmailResult.png?raw=true)


CommandJson Field will give you json representation of the command that is generated to execute this call.

```json
{
  "categories": null,
  "from": {
    "email": "johnDoe@email.com",
    "name": null
  },
  "reply_to": null,
  "personalizations": [
    {
      "to": [
        {
          "email": "emre@fluentley.com",
          "name": null
        }
      ],
      "cc": null,
      "bcc": null,
      "subject": null,
      "substitutions": null,
      "custom_args": null,
      "headers": null,
      "send_at": null
    }
  ],
  "content": [
    {
      "value": "Hello World",
      "type": "text/plain"
    }
  ],
  "attachments": null,
  "sections": null,
  "custom_args": null,
  "subject": "Test Email From Fluentley.SendGrid",
  "send_at": null,
  "mail_settings": null,
  "tracking_settings": null,
  "asm": null,
  "sandbox_mode": null,
  "headers": null,
  "template_id": null,
  "ip_pool_name": null
}
```

The json above can be stored and executed.

### Execute Command Method

```cs
  var commandResult = await sendGridService.SendEmail().ExecuteCommand("{Json Command Above}")
```

### Smart Email Sending With Substutions
This is a conditional email, first of all this approach decrease the calculation time also, it is very efficient to keep a copy of your send history, after the execution with the returned command, you can also reconstruct email that is sent with keeping low volume of data in your presistent store.
```cs
var filePath = @"{SomePath}";

            var result = await Service.SendEmail(sendEmailOption => sendEmailOption
                .From("from@email.com")
                .ReplyTo("replyTo@email.com", "John")
                .Subject($"Test Email From Fluentley.SendGrid {DateTime.UtcNow:d}")
                .AddCategory("Test Cateogry")
                .AddRecipient(recipientOption => recipientOption
                    .AddTo("recipeint1@email.com")
                    .AddSubstitution("{{FirstName}}", "Alex")
                    .AddSubstitution("{{LastName}}", "Hunter")
                    .AddSubstitution("{{Salutation}}", "Mr.")
                    .AddSubstitution("{{CommunicationReason}}", "{{BadNewsCommunication}}"))
                .AddRecipient(recipientOption => recipientOption
                    .AddTo("recipeint2@email.com")
                    .AddSubstitution("{{FirstName}}", "Cara")
                    .AddSubstitution("{{LastName}}", "Lightfoot")
                    .AddSubstitution("{{Salutation}}", "Mrs.")
                    .AddSubstitution("{{CommunicationReason}}", "{{GoodNewsCommunication}}"))
                .AddContent(contentOption => contentOption
                    .Value("{{Salutation}} {{FirstName}} {{LastName}}, <br> {{CommunicationReason}}")
                    .Type("text/html"))
                .AddAttachments(option => option
                    .FileName("Test File.txt")
                    .Content(Convert.ToBase64String(File.ReadAllBytes(filePath))))
                .AddSection("{{GoodNewsCommunication}}", "We contact you in order to give you a great news")
                .AddSection("{{BadNewsCommunication}}", "Unfortunately, we have a bad news for you")
                .TrackingSettings(option => option
                    .ClickTracking(clickTrackingOption => clickTrackingOption
                        .Enable(true))
                    .OpenTracking(openTracking => openTracking
                        .Enable(true))
                    .SubscriptionTracking(openTracking => openTracking
                        .Enable(true))
                )
            ).Execute();
```

You can create a more comprehensive email construction, we give support its full functionality. Please make sure to check sendgrid email sending documentation.

So email contents of the execution above will look like

> Mr. Alex Hunter, Unfortunately, we have a bad news for you  
> Mrs. Cara Lightfoot, We contact you in order to give you a great news  

### Generate Request
There are three different command executions `Execute()`, `ExecuteCommand()`, `GenerateRequest()` I have already used two of them with the samples above, the last one is generate request command. You are going to see excessive use of this particular in the integration tests. It is used for generating a request without executing it and it is going to return a `IResult<HttpRequestMessage>` result.


![Generate Request](https://github.com/fluentley/Fluentley.Sendgrid/blob/master/ReadMeFiles/SendEmailResult.png?raw=true)

You can use the returned httprequest and pass it to any HttpClient and execute it. The idea is that you may have some custom logic, might be logging or a builtin framework and you need it to go through that pipeline. This method allows you to do that.

### Api Functionalities

I will talk about a few functions due, to sendgrid documentation has it already in details, you will find the respected calls based on the documentation.

#### Create Alert
```cs
            var alert = new Alert
            {
                EmailTo = "example@example.com",
                Frequency = Frequency.Daily,
                Type = AlertType.StatisticsNotification
            };

            var command = Service.CreateAlert(option => option.ByModel(alert));

           await command.Execute();
```
Or you can use it as follows, both of commands are equvant to each other.
```cs
            var command = Service.CreateAlert(option => option
                            .AlertFrequency(Frequency.Daily)
                            .SendAlertTo("example@example.com")
                            .Type(AlertType.StatisticsNotification)
                        );

           await command.Execute();
```
#### List Alert

Basic query for returning all Alerts 
```cs

 var alerts = await Service.Alerts().Execute();

```
This particular method encapsulates [Fluentley.QueryBuilder](https://github.com/fluentley/Fluentley.QueryBuilder) package.


Also, you can use `UseInMemoryQuery()` which has bunch of query options for you, here are the ones that are supported.
- QueryBy
- Paging
- DynamicContains
- DynamicSort

Or you can have a paged version of your call as well as filtering done for you.
```cs
var alerts = await Service.Alerts(options=> options.
                UseInMemoryQuery(queryOption=> queryOption
                    .QueryBy(query=> query
                        .Where(x=> x.EmailTo == "emre@fluentley.com"))
                    .Paging(0, 5)
                )
            ).Execute();
```

#### Find Alert
```cs
 var result =  await Service.Alert(option => option
                    .ById("1")
                ).Execute();
```

Each different Api will have differnt options on the list or on the find level. But the ones I talked about are the common accross all.

Also, one thing I haven't really talked about which is very important is the `UseContextOption()` again it is common across all of the calls.

#### Context Option
You can execute any of the methods, using different ApiKey or operations can be done on behalf of a sub user.
```cs
 var result = await Service.Alert(option => option
                .UseContextOption(contextOption => contextOption
                    .UseApiKey("{Sub User Api Key - or any apiKey}")
                    .OnBehalfOfSubUser("{Behalf Of SubUser Name}")
                )
                .ById("1")
            ).Execute();
```
