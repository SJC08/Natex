[![NuGet](https://img.shields.io/nuget/v/Asjc.Natex)](https://www.nuget.org/packages/Asjc.Natex/)

**Natex (Natural Expression)** provides a quick way to match objects.

> Warning: This library is still under development! It's unstable, and the public API can change at any time!

## NatexMatcher

In essence, most of the matching and other work is performed by `INatexMatcher`.

The library already implements Matchers such as `VariableMatcher`、`StringMatcher`、`ComparisonMatcher`、`RangeMatcher`、`RegexMatcher`、`PropertyMatcher`、`MultiPatternMatcher`, and so on.

You can also create your **own** Matcher. You can get started quickly with the `NatexMatcher`, `NatexMatcher<TValue>`, `NatexMatcher<TValue, TData>` **class**, or the `INatexMatcher` **interface**.

Read the source code for more information!
