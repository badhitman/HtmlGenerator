# HtmlGenerator
HTML Generator - .Net Core. (используется в [конструкторе](https://github.com/badhitman/DesignerApp/tree/main/ConstructorService))
Построение DOM в виде C# объектов и генерация HTML разметки (в том числе Bootstrap).

Пример 1:
```C#
// Создаём объект передаём первым параметром текст Label-а, а вторым идентификатор Input-а
CheckboxCustomInputBootstrap mybox = new ("Check this custom checkbox", "customControlValidation1");
// указываем, что поле обязательно для заполенния (если это необходимо).
// От этого зависит наличие у CheckBox-а реакционных уведомлений (invalid-feedback и/или valid-feedback), 
// текст которых устанавливается через соответсвующие поля mybox.valid_feedback_text и mybox.invalid_feedback_text
mybox.Input.required = true;
// получаем готовый форматированый HTML
string test_s = mybox.GetHTML();
```
Результат => HTML.Bootstrap:
```HTML
<div class="custom-control custom-checkbox">
	<input type="checkbox" required id="customControlValidation1" class="custom-control-input" >
	<label for="customControlValidation1" class="custom-control-label">Check this custom checkbox</label>
	<div id="invalid-tooltip-customControlValidation1" class="invalid-feedback">Пожалуйста, установите Checkbox</div>
	<input type="hidden" value="off" >
</div>
```

Пример 2
```C#
TextInputBootstrap my_text_input = new ("Email address", "exampleInputEmail1")
    .SetTypeForInput(InputTypesEnum.email)
    .SetPlaceholderForInput("Enter email")
    .SetInputInfoFooter("We'll never share your email with anyone else.");

string test_s = my_text_input.GetHTML();
```
Результат => HTML.Bootstrap:
```HTML
<div class="form-group">
	<label for="exampleInputEmail1">Email address</label>
	<input aria-describedby="exampleInputEmail1Help" type="email" placeholder="Enter email" id="exampleInputEmail1" name="exampleInputEmail1" class="form-control" >
	<small id="exampleInputEmail1Help" class="form-text text-muted">We'll never share your email with anyone else.</small>
</div>
```

Пример 3:
```C#
GroupElementsBootstrap my_test_obj = new () { aria_label = "Basic example group" }
    .AddDomNode(new ButtonBootstrap("Left", VisualBootstrapStylesEnum.secondary))
    .AddDomNode(new ButtonBootstrap("Middle", VisualBootstrapStylesEnum.secondary))
    .AddDomNode(new ButtonBootstrap("Right", VisualBootstrapStylesEnum.secondary));

string test_string = my_test_obj.GetHTML();
```
Результат => HTML.Bootstrap [view original demo](https://getbootstrap.com/docs/4.3/components/button-group/#basic-example):
```HTML
<div role="group" aria-label="Basic example group" class="btn-group">
	<button type="button" class="btn btn-secondary">Left</button>
	<button type="button" class="btn btn-secondary">Middle</button>
	<button type="button" class="btn btn-secondary">Right</button>
</div>
```
Пример 4:
```C#
string test_string;
GroupElementsBootstrap my_group;

GroupsToolbarBootstrap my_toolbar = new () { aria_label = "Toolbar with button groups" };
my_group = new () { aria_label = "First group" };
my_group.AddCSS("mr-2");
for (int i = 1; i <= 4; i++)
   my_group.AddDomNode(new ButtonBootstrap(i.ToString(), VisualBootstrapStylesEnum.secondary));

my_toolbar.Groups.Add(my_group);
//
my_group = new () { aria_label = "Second group" };
my_group.AddCSS("mr-2");
for (int i = 5; i <= 7; i++)
  my_group.AddDomNode(new ButtonBootstrap(i.ToString(), VisualBootstrapStylesEnum.secondary));

my_toolbar.Groups.Add(my_group);
//
my_group = new () { aria_label = "Third group" };
my_group.AddDomNode(new ButtonBootstrap("8", VisualBootstrapStylesEnum.secondary));
my_toolbar.Groups.Add(my_group);

test_string = my_toolbar.GetHTML();
```
Результат => HTML.Bootstrap [view original demo](https://getbootstrap.com/docs/4.3/components/button-group/#button-toolbar):
```HTML
<div role="toolbar" aria-label="Toolbar with button groups" class="btn-toolbar">
	<div role="group" aria-label="First group" class="btn-group mr-2">
		<button type="button" class="btn btn-secondary">1</button>
		<button type="button" class="btn btn-secondary">2</button>
		<button type="button" class="btn btn-secondary">3</button>
		<button type="button" class="btn btn-secondary">4</button>
	</div>
	<div role="group" aria-label="Second group" class="btn-group mr-2">
		<button type="button" class="btn btn-secondary">5</button>
		<button type="button" class="btn btn-secondary">6</button>
		<button type="button" class="btn btn-secondary">7</button>
	</div>
	<div role="group" aria-label="Third group" class="btn-group">
		<button type="button" class="btn btn-secondary">8</button>
	</div>
</div>
```

P.S.
Bootstrap работает поверх низкоуровневого HTML генератора.
Приведём пример низкоуровневого HTML
```C#
string test_s;
////////////////////////////////////////////
// Создадим тестовую таблицу с информацией о людях
table my_table = new table();
////////////////////////////////////////////
// Формируем колонки и заголовки к ним
my_table.THead
    .AddColumn("№ п/п")
    .AddColumn("Имя")
    .AddColumn("Фамилия")
    .AddColumn("Телефон");
// далее заполняем данным таблицу
my_table.TBody
    .AddRow(new string[] { "1", "Иван", "Санду", "телефона нет" })
    .AddRow(new string[] { "2", "Игорь", "Фомин", "+79995552244" });
// Получаем HTML
test_s = my_table.GetHTML();
```
Результат => HTML
```HTML
<table>
    <thead>
        <tr>
            <th>
                № п/п
            </th>
            <th>
                Имя
            </th>
            <th>
                Фамилия
            </th>
            <th>
                Телефон
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                1
            </td>
            <td>
                Иван
            </td>
            <td>
                Санду
            </td>
            <td>
                телефона нет
            </td>
        </tr>
        <tr>
            <td>
                2
            </td>
            <td>
                Игорь
            </td>
            <td>
                Фомин
            </td>
            <td>
                +79995552244
            </td>
        </tr>
    </tbody>
</table>
```

> [!NOTE]
> Больше примеров можно увидеть в demo файлах: для простого [html](./demo.cs); для [Bootstrap](./demo_bootstrap.cs).