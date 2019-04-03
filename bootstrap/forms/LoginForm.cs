////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////


using HtmlGenerator.bootstrap;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap.forms
{
    public class LoginForm : Card
    {
        /// <summary>
        /// Форма отправки данных
        /// </summary>
        public form html_form = new form()
        {
            Id_DOM = "login_form_id",
            css_class = "was-validated",
            target = TargetsEnum._self,
            method_form = MethodsFormEnum.POST
        };

        public LoginForm()
        {
            CardHeader = "Вход/Регистрация";
            html_form.SetAttribute("novalidate", null);
        }
    }
}
