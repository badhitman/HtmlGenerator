////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Login form
/// </summary>
public class LoginFormBootstrap : CardBootstrap
{
    /// <summary>
    /// Форма отправки данных
    /// </summary>
    public form html_form = new()
    {
        Id_DOM = "login_form_id",
        target = TargetsEnum._self,
        method_form = MethodsFormEnum.POST
    };

    /// <summary>
    /// Login form
    /// </summary>
    public LoginFormBootstrap()
    {
        html_form.AddCSS("was-validated");
        CardHeader = "Вход/Регистрация";
        html_form.SetAttribute("novalidate", null);
    }
}