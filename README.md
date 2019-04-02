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
*JS код не относится непосредственно к Bootstrap. Это лайфхак для кроссбраузерной стандартизации отпарвки ЧекБокс-а формой. В связи с тем, что Bootstrap использует jQuery - мы смело можем считать что эта библиотека подключена*