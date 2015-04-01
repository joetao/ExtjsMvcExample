//Ext.define("MyApp.store.User", {
//    extend: "Ext.data.Store",
//    model: "MyApp.model.User",
//    data: [
//        { name: "Tom", age: 5, phone: "123456" },
//        { name: "Jerry", age: 3, phone: "654321" }
//    ]
//});

Ext.define("MyApp.store.User", {
    extend: "Ext.data.Store",
    model: "MyApp.model.User",
    proxy: {
        type: 'ajax',
        api: {
            read: '/Home/GetUserList',
            update: '/Home/UpdateUser',
            model: "MyApp.model.User"
        },
        actionMethods: {
            create: "POST", read: "POST", update: "POST", destroy: "POST"
        },
        reader: {
            type: 'json'
        },
        writer: {
            type: 'json'
        }
    }
});