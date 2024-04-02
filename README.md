**Natex (Natural Expression)** provides a quick way to match objects.

> Warning: This library is still under development! It's unstable, and the public API can change at any time!

## Customize NatexMatcher

1. Create a class and inherit from `NatexMatcher`.
2. Consider the following ways:
   1. **Override `Match(object? obj, Natex natex)`**
      - Use this method only if your logic is simple or performance is not a concern.
      - We will help you save `natex` in `Parse(Natex natex)` and call `Match(object? obj, Natex natex)` in `Match(object? obj)` by passing `natex`.
   
   2. **Override `Parse(Natex natex)` and `Match(object? obj)`**
      - Parse `natex` in `Parse` and store it, then process `obj` in `Match`.
      - This should offer better performance, especially when matching multiple items because there will be no redundant processing.
   
      - **Do not** forget to assign `Parsed` to `true` during `Parse`! (Unless you know why not doing so)
   
   3. Others. Read the source code (which is simple) and define your specific operations.
3. The `Match` method should return **0**, **1**, or **2**, which respectively signify:
   - **0**: No match. Natex will be passed to the next Matcher. Generally, return this if you can't parse it.
   - **1**: Match. `Natex.Match` will return `true`. Generally, return this if you successfully match.
   - **2**: No match. `Natex.Match` will return `false`. Generally, return this if your matching fails.

