# HtmlGenerator
HTML Generator - .Net Core

Построение DOM в виде C# объектов и генерация HTML разметки

Пример 1:
```
CheckboxCustomInput mybox = new CheckboxCustomInput("Check this custom checkbox", "customControlValidation1");
mybox.Input.required = true;
string test_s = mybox.GetHTML();
```
Результат => HTML.Bootstrap:
```
<div class="custom-control custom-checkbox">
	<input type="checkbox" required id="customControlValidation1" class="custom-control-input" >
	<label for="customControlValidation1" class="custom-control-label">Check this custom checkbox</label>
	<div id="invalid-tooltip-customControlValidation1" class="invalid-feedback">Укажите значение</div>
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
*JS код с одной стороны не относится непосредственно к Bootstrap разметке, но у меня он автоматически добавляется ко всем Bootstrap [checkbox]-ам. Это же относится к [hidden] [input]-у со значением "off" или "on"*.
*Это такой лайфхак для кроссбраузерной стандартизации отпарвки [checkbox]-а формой. Разные браузеры могут по разному отправлять значения [checkbox]-а. Для стандартизации этой процедуры с [checkbox]-ом в паре держим его "тень" в виде скрытого [input]-а и контролируем значение теневого значения синхронизируя с основным*

Пример 2
```
BaseTextInput my_text_input = new BaseTextInput("Email address", "exampleInputEmail1");
my_text_input.Input.type = InputTypesEnum.email;
my_text_input.Input.placeholder = "Enter email";
my_text_input.InputInfoFooter = "We'll never share your email with anyone else.";
string test_s = my_text_input.GetHTML();
```
Результат => HTML.Bootstrap:
```
<div class="form-group">
	<label for="exampleInputEmail1">Email address</label>
	<input aria-describedby="exampleInputEmail1Help" type="email" placeholder="Enter email" id="exampleInputEmail1" name="exampleInputEmail1" class="form-control" >
	<small id="exampleInputEmail1Help" class="form-text text-muted">We'll never share your email with anyone else.</small>
</div>
```