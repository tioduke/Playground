/// <reference path="../lib/jquery-validation/dist/jquery.validate.js" />
/// <reference path="../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js" />

jQuery.validator.addMethod("nasvalidation", function (value, element) {
	if (!value)
		return true;
	if (value.length != 9) 
		return false;

	var s = 0;
	for (var i=0; i<9; i++) {
		var x = eval(value.substring(i, i+1));
		i % 2 ? x << 1 > 9 ? s += (x << 1) - 9 : s += x << 1 : s += x;
	}
	return s % 10 ? false : true;
});

jQuery.validator.unobtrusive.adapters.add("nasvalidation", function (options) {
	options.rules["nasvalidation"] = "#"; 
    options.messages["nasvalidation"] = options.message;
});
