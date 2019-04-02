# HtmlGenerator
HTML Generator - .Net Core

Построение DOM в виде C# объектов и генерация HTML разметки

```
CheckboxCustomInput mybox = new CheckboxCustomInput("Check this custom checkbox", "customControlValidation1");
mybox.Input.required = true;
string test_s = mybox.GetHTML();
```
Это сгенерирует Bootstrap HTML разметку следующего содержания:
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
*JS код с одной стороны не относится непосредственно к Bootstrap разметке, но у меня он автоматически добавляется ко всем Bootstrap checkbox-ам. Это же относится к скрытому полю: <input type="hidden" value="off" >*
*Это лайфхак для кроссбраузерной стандартизации отпарвки ЧекБокс-а формой. Разные браузеры могут по разному отправлять чекбокс. Для стандартизации этой процедуры с чекбоксом в паре держим его "тень" в виде скрытого input-а и контролируем значение теневого значения синхронизируя с основным*