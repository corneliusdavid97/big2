var express = require('express');
var app = express();

var server = require('http').createServer(app);
var io = require('socket.io').listen(server);

app.set('port',3000);

var clients = [];

io.on("connection", function (socket) {
    var currentUser;

    socket.on("USER_CONNECT", function () {
        console.log('User connected');
        for (var i = 0; i < clients.length; i++) {
            socket.emit("USER_CONNECTED", {name: clients[i].name});
            console.log("User name " + clients[i].name + " is connected");
        }
    });

    socket.on("JOIN_LOBBY", function (data) {
        console.log(data);
        currentUser = {
            name: data.name
        }
        clients.push(currentUser);
        socket.emit("JOIN_LOBBY",JSON.stringify(clients));
    });

    socket.on("PLAY",function(){

    });

    socket.on("TOUCH",function(data){
        console.log(data.name+" "+data.selected+" "+data.card);
    })

    socket.on("disconnect",function(){
        socket.broadcast.emit("USER_DISCONNECTED",currentUser);
        for(var i=0;i<clients.length;i++){
            if(clients[i].name===currentUser.name){
                console.log("User "+clients[i].name+" disconnected");
                clients.splice(i,1);
            }
        }
    })

});

server.listen(app.get("port"), function () {
    console.log("----- SERVER IS RUNNING -----");
});