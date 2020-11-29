let http = require("http");
let url = require("url");
let port = 2000;
let fs = require("fs")
let path = require("path");




 http.createServer(function(req,res) {
   
   fs.readFile("index.html",(err,data) => {
       if(err) throw new Error(err);
       res.end(data)
   })
}).listen(port,function() {
    console.log("The second server run!!!!")
})









