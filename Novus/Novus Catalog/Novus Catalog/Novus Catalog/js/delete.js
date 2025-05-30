jQuery(function($) {
  	$("form input[id='check_all']").click(function() { // triggered check

		var inputs = $("form input[type='checkbox']"); // get the checkbox

		for(var i = 0; i < inputs.length; i++) { // count input tag in the form
			var type = inputs[i].getAttribute("type"); //  get the type attribute
				if(type == "checkbox") {
					if(this.checked) {
						inputs[i].checked = true; // checked
					} else {
						inputs[i].checked = false; // unchecked
				 	 }
				}
		}
	});
	
	$("form input[id='delete']").click(function() {  // triggered submit

		var count_checked = $("[name='student[]']:checked").length; // count the checked 
				
		if(count_checked == 0) {
			alert("Please select a record(s) to delete.");
			return false;
		}
		if(count_checked == 1) {
			return confirm("Are you sure you want to delete this record?");
		} else {
			return confirm("Are you sure you want to delete these records?");
		  }
	});
	
	
}); // jquery end
