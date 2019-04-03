# HtmlGenerator
HTML Generator - .Net Core

Построение DOM в виде C# объектов и генерация HTML разметки (в том числе Bootstrap 4.3). Разрабатывается как "View" часть платфлормы "CC#CMF - Ромашка", но может использоваться отдельно от неё (например для генерации документаций или презентаций)

Пример 1:
```C#
// Создаём объект передаём первым параметром текст Label-а, а вторым идентификатор Input-а
CheckboxCustomInput mybox = new CheckboxCustomInput("Check this custom checkbox", "customControlValidation1");
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
	<script type="text/javascript">
		jQuery(document).ready(function () {
			jQuery('#customControlValidation1').change(function () {
				if (jQuery(this).prop('checked')) {
					jQuery('input[name=customControlValidation1').val('on');
				}
				else {
					jQuery('input[name=customControlValidation1').val('off');
				}
			});
		});
	</script>
</div>
```
*JS код не относится непосредственно к Bootstrap разметке, но добавляется ко всем Bootstrap [checkbox]-ам. В паре с этим добавлен [hidden] [input]-у со значением "off" или "on"*.
*Это такой хак для кроссбраузерной стандартизации отпарвки [checkbox]-а формой. Разные браузеры могут по разному отправлять значения [checkbox]-а. Использован приём, когда с [checkbox]-ом в паре существует его "тень" в виде скрытого [input]-а. Контролируется значение теневого [input]-а синхронизируя с основным, а на стороне сервера обрабатывается именно "теневой [input]"*

Пример 2
```C#
BaseTextInput my_text_input = new BaseTextInput("Email address", "exampleInputEmail1");
my_text_input.Input.type = InputTypesEnum.email;
my_text_input.Input.placeholder = "Enter email";
my_text_input.InputInfoFooter = "We'll never share your email with anyone else.";
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
*Тут C# кода как-буд-то больше чем HTML кода на выходе, но это от подробных настроек Input-a*

Пример 3:
```C#
GroupElements my_test_obj = new GroupElements() { aria_label = "Basic example group" };
my_test_obj.Childs.Add(new Button("Left", VisualBootstrapStylesEnum.secondary));
my_test_obj.Childs.Add(new Button("Middle", VisualBootstrapStylesEnum.secondary));
my_test_obj.Childs.Add(new Button("Right", VisualBootstrapStylesEnum.secondary));
string test_string = my_test_obj.GetHTML();
```
Результат => HTML.Bootstrap:
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
GroupElements my_group;

GroupsToolbar my_toolbar = new GroupsToolbar() { aria_label = "Toolbar with button groups" };
my_group = new GroupElements() { aria_label = "First group" };
my_group.css_class += " mr-2";
for (int i = 1; i <= 4; i++)
	my_group.Childs.Add(new Button(i.ToString(), VisualBootstrapStylesEnum.secondary));
            
my_toolbar.Groups.Add(my_group);
//
my_group = new GroupElements() { aria_label = "Second group" };
my_group.css_class += " mr-2";
for (int i = 5; i <= 7; i++)
	my_group.Childs.Add(new Button(i.ToString(), VisualBootstrapStylesEnum.secondary));

my_toolbar.Groups.Add(my_group);
//
my_group = new GroupElements() { aria_label = "Third group" };
my_group.Childs.Add(new Button("8", VisualBootstrapStylesEnum.secondary));
my_toolbar.Groups.Add(my_group);

test_string = my_toolbar.GetHTML();
```
Результат => HTML.Bootstrap:
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
Bootstrap работет поверх низкоуровневого HTML генератора.
Приведём пример низкоурвоневого HTML
```C#
string test_s;
////////////////////////////////////////////
// Создадим тестовую таблицу с информацией о людях
table my_table = new table();
////////////////////////////////////////////
// Формируем колонки и заголовки к ним
my_table.Thead.AddColumn("№ п/п");
my_table.Thead.AddColumn("Имя");
my_table.Thead.AddColumn("Фамилия");
my_table.Thead.AddColumn("Телефон");
// далее заполняем данным таблицу
my_table.Tbody.AddRow(new string[] { "1", "Иван", "Санду", "телефона нет" });
my_table.Tbody.AddRow(new string[] { "2", "Игорь", "Фомин", "+79995552244" });
my_table.Tbody.AddRow(new string[] { "3", "Павел", "Рыбин", "+78886667722" });
my_table.Tbody.AddRow(new string[] { "4", "Евгений", "Шмидт", "+73334445599" });
my_table.Tbody.AddRow(new string[] { "5", "Русалина", "Санду", "телефона нет" });
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
		<tr>
			<td>
			3
			</td>
			<td>
			Павел
			</td>
			<td>
			Рыбин
			</td>
			<td>
			+78886667722
			</td>
		</tr>
		<tr>
			<td>
			4
			</td>
			<td>
			Евгений
			</td>
			<td>
			Шмидт
			</td>
			<td>
			+73334445599
			</td>
		</tr>
		<tr>
			<td>
			5
			</td>
			<td>
			Русалина
			</td>
			<td>
			Санду
			</td>
			<td>
			телефона нет
			</td>
		</tr>
	</tbody>
</table>
```