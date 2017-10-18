var app =require('express')();
var server = require('http').Server(app);
var io=require('socket.io')(server);

server.listen(3000);

var clients = [];

io.sockets.on("connection", function (socket) {
    var currentUser;

    socket.on("USER_CONNECT", function (data) {
        console.log('User connected');
        currentUser = {
            name: data.name
        }
        for (var i = 0; i < clients.length; i++) {
            socket.emit("USER_CONNECTED", {name: clients[i].name});
            console.log("User name " + clients[i].name + " is connected");
        }
        clients.push(currentUser);
        var tmp={};
        for(var i=0;i<clients.length;i++){
            tmp["client"+i]=clients[i].name;
        }
        io.sockets.emit("JOIN_LOBBY",tmp);
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