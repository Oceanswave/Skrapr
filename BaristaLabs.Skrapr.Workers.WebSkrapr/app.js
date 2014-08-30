var AWS = require('aws-sdk');
var fs = require("fs");
var async = require('async');

var skraprTargetPath = "target.json";

//TODO: Credentials!
AWS.config.region = 'us-east-1';

var invokePhantomJS = function() {
    var path = require('path');
    var childProcess = require('child_process');
    var phantomjs = require('phantomjs');

    var phantomJSErrorPath = "skrapr.err";
    var binPath = phantomjs.path;

    var childArgs = [
        path.join(__dirname, '/lib/phantomjs-script.js'),
        "--config=/lib/phantomjs-config.json"
    ];

    console.log("starting phantomjs...");
    childProcess.execFile(binPath, childArgs, function(err, stdout, stderr) {
        if (err) {
            if (fs.existsSync(phantomJSErrorPath)) {
                var error = fs.readFileSync(phantomJSErrorPath, "utf8");
                console.log(error);
            } else
                console.log(err); // an error occurred
        } else
            console.log(stdout); // successful response
    });
};

var die = false;

//Add a log entry that indicates this worker is ready...
async.whilst(
    function() {
         return !die;
    },
    function (callback) {
        //Monitor configured AWS SQS queue for a new target url. The queued item should contain the account/project/skrapr and target
    
        //Get target definition from couchdb.
    
        //save the target to target.json
    
        //Invoke phantomjs. 
        invokePhantomJS();
    
        console.log("Waiting...");
        setTimeout(callback, 1000);
    },
    function (err) {
        //Shutdown.
    }
);
