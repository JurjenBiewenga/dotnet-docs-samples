// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

// This is a generated sample ("Request", "translate_v3_detect_language")

using CommandLine;
// [START translate_v3_detect_language]
using Google.Cloud.Translate.V3;
using System;

namespace Google.Cloud.Translate.V3.Samples
{
    public class TranslateV3DetectLanguage
    {
        /// <summary>
        /// Detecting the language of a text string
        /// </summary>
        /// <param name="text">The text string for performing language detection</param>
        public static void SampleDetectLanguage(string text, string projectId)
        {
            TranslationServiceClient translationServiceClient = TranslationServiceClient.Create();
            // string text = "Hello, world!"
            // string project = "[Google Cloud Project ID]"
            DetectLanguageRequest request = new DetectLanguageRequest
            {
                ParentAsLocationName = new LocationName(projectId, "global"),
                Content = text,
                MimeType = "text/plain",
            };
            DetectLanguageResponse response = translationServiceClient.DetectLanguage(request);
            // Display list of detected languages sorted by detection confidence.
            // The most probable language is first.
            foreach (DetectedLanguage language in response.Languages)
            {
                // The language detected
                Console.WriteLine($"Language code: {language.LanguageCode}");
                // Confidence of detection result for this language
                Console.WriteLine($"Confidence: {language.Confidence}");
            }
        }
    }

    // [END translate_v3_detect_language]

    public class TranslateV3DetectLanguageMain
    {
        public static void Main(string[] args)
        {
            new Parser(with => with.CaseInsensitiveEnumValues = true).ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                    TranslateV3DetectLanguage.SampleDetectLanguage(opts.Text, opts.ProjectId));
        }

        public class Options
        {
            [Option("text", Default = "Hello, world!")]
            public string Text { get; set; }

            [Option("project_id", Default = "[Google Cloud Project ID]")]
            public string ProjectId { get; set; }
        }
    }
}
