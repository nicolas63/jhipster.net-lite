// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace BlazorWebClient.Data;

public class SelectionElement
{
    public const string InitializationReference = "Initialization";

    public const string LanguageReference = "Language";

    public const string ClientReference = "Client";

    public const string SonarReference = "Sonar";

    public const string GithubActionReference = "GithubAction";

    public string Name { get; set; }

    public string Reference { get; }

    public SelectionElement(string name, string reference)
    {
        Name = name;
        Reference = reference;
    }

    public override bool Equals(object? obj) => obj is SelectionElement element && Reference == element.Reference;
}
