﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector.DirectLine;
using Nexmo.Api;
using Nexmo.Api.Voice;
using ProxiCall.Web.Helpers;
using ProxiCall.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ProxiCall.Web.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VoiceController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private NCCOHelpers _nccohelper;

        private BotConnector _botConnector;
        private NexmoConnector _nexmoConnector;

        private string _userTextReply;

        public VoiceController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _nccohelper = new NCCOHelpers();

        }

        public IActionResult Index()
        {
            ViewData["NCCOButtonText"] = "Create NCCO";
            return View();
        }

        [HttpGet]
        public ActionResult MakeTextToSpeechCall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeTextToSpeechCall(string to)
        {
            var NEXMO_FROM_NUMBER = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"];
            var NEXMO_TO_NUMBER = to;
            var NEXMO_CALL_ANSWER_URL = "https://raw.githubusercontent.com/nexmo-community/ncco-examples/gh-pages/first_call_talk.json";

            var results = Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = NEXMO_TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_FROM_NUMBER
                },
                answer_url = new[]
                {
                    NEXMO_CALL_ANSWER_URL
                }
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PlayAudioToCaller()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlayAudioToCaller(string to)
        {
            var NEXMO_FROM_NUMBER = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"];
            var NEXMO_TO_NUMBER = to;
            var NEXMO_CALL_ANSWER_URL = "https://raw.githubusercontent.com/nexmo-community/ncco-examples/gh-pages/first_call_speech.json";

            var results = Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = NEXMO_TO_NUMBER
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = NEXMO_FROM_NUMBER
                },
                answer_url = new[]
                {
                    NEXMO_CALL_ANSWER_URL
                }
            });

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateTalkNCCO(string text, string voiceName)
        {
            _nccohelper.CreateTalkNCCO(_hostingEnvironment.WebRootPath, text, voiceName);

            ViewData["NCCOButtonText"] = "NCCO Created";
            return View("MakeTextToSpeechCall");
        }

        [HttpPost]
        public ActionResult CreateStreamNCCO(string[] streamUrl, int level = 0, bool bargeIN = false, int loop = 1)
        {
            _nccohelper.CreateStreamNCCO(_hostingEnvironment.WebRootPath, streamUrl, level, bargeIN, loop);

            ViewData["NCCOButtonText"] = "NCCO Created";
            return View("PlayAudioToCaller");
        }

        [HttpGet("ws")]
        public async Task GetAudio()
        {
            if (HttpContext.Request.Path == "/ws")
            {
                if (HttpContext.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                    _botConnector = new BotConnector();
                    _nexmoConnector = new NexmoConnector(webSocket);

                    await _botConnector.StartWebsocket(OnBotReplyHandler);
                    await _nexmoConnector.WebsocketHandler(OnAudioReceivedAsync);
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                }
            }
        }

        public async void OnBotReplyHandler(IList<Activity> botReplies)
        {
            var replyNeeded = botReplies.Last().InputHint != "ignoringInput";

            foreach(var activity in botReplies)
            {
                /*var audioToSend = await TextToSpeech(activity.Text);
                _nexmoConnector.SendAudioAsync(audioToSend);*/
            }
        }

        public async Task OnAudioReceivedAsync(byte[] audioReceived)
        {
            /*var textFromUser = await SpeechToText(audioReceived);
            var activity = new Activity();
            activity.From = new ChannelAccount("userid", "username"); //TODO replace id and name with userid and username from nexmo
            activity.Type = "message";
            activity.Text = textFromUser;
            await _botConnector.SendMessageAsync(activity);*/
        }
    }
}