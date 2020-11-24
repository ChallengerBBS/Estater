let http = require("http");
let url = require("url");
let port = 2000



let server = http.createServer(function(req,res) {
   res.end("Hello World")
}).listen(port,function() {
    console.log("The second server run!!!!")
})



console.log(
    process.hrtime()
)




