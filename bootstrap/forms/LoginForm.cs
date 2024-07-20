////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////

using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

public class LoginForm : Card
{
    /// <summary>
    /// Форма отправки данных
    /// </summary>
    public form html_form = new form()
    {
        Id_DOM = "login_form_id",
        target = TargetsEnum._self,
        method_form = MethodsFormEnum.POST
    };

    public LoginForm()
    {
        html_form.AddCSS("was-validated");
        CardHeader = "Вход/Регистрация";
        html_form.SetAttribute("novalidate", null);
    }
}