## Bemol: a simple web framework for C#

```cs
using Bemol;

public class HelloWorld {
    public static void Main() {
        App app = new Bemol.App().Start(7000);
        app.Get("/", (ctx) => ctx.Result("Hello World!"));
    }
}
```