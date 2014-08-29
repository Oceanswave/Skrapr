var page = require('webpage').create();
var fs = require('fs');

var path = "target.json";
var errorPath = "skrapr.err";

//load the target from file.
if (!fs.exists(path)) {
    fs.write(errorPath, "Unable to locate target.json", 'w');
    phantom.exit(1);
} else {
    var skrapr = fs.open(path, 'r');

    page.open('http://www.google.com', function() {
        page.render('example.png');
        phantom.exit(0);
    });
}