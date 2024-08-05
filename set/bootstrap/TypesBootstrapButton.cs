////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

namespace HtmlGenerator.set.bootstrap;

/// <summary>
/// В Bootstrap 4.3 кнопки могут быть представлены в трёх различных типах: [button] [a] [input]
/// The .btn classes are designed to be used with the [button] element. However, you can also use these classes on [a] or [input] elements (though some browsers may apply a slightly different rendering).
/// </summary>
public enum TypesBootstrapButton
{
    /// <summary>
    /// В виде [button] контейнера
    /// </summary>
    button,

    /// <summary>
    /// В виде [a] контейнера
    /// </summary>
    a,

    /// <summary>
    /// В виде [input] контейнера
    /// </summary>
    input
}