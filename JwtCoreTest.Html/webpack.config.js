var webpack = require("webpack");
var vendors_dir = __dirname + "/Scripts/vendors";

var config = {
    addVendor: function (name, path) {
        this.resolve.alias[name] = path;
        this.noParse.push(new RegExp(path));
    },
    entry: {
        app: ["./Scripts/app/app.tsx"],
        vendors: ["jquery", "jquery-CORS", "bootstrap", "react", "react-router", "rx", "toastr"]
    },
    resolve: {
        alias: {}
    },
    output: {
        path: "./Scripts",
        filename: "site.js"
    },
    module: {
        loaders: [
            {
                test: /\.tsx?$/,
                loader: "ts-loader"
            }
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            'window.jQuery': 'jquery'
        }),
        new webpack.optimize.CommonsChunkPlugin("vendors", "vendors.js")
    ],
    noParse: [
        /[\/\\]node_modules.*/,
    ]
};

config.addVendor("jquery", vendors_dir + "/jquery/jquery.js");
config.addVendor("jquery-CORS", vendors_dir + "/jquery-ajax-transport-xdomainrequest/jQuery.XDomainRequest.js");
config.addVendor("bootstrap", vendors_dir + "/bootstrap/bootstrap.js");
config.addVendor("react", vendors_dir + "/reactjs/react.js");
config.addVendor("react-dom", vendors_dir + "/reactjs/react-dom.js");
config.addVendor("react-router", vendors_dir + "/react-router/ReactRouter.js");
config.addVendor("rx", vendors_dir + "/rxJs/rx.all.js");
config.addVendor("toastr", vendors_dir + "/toastr/toastr.min.js");

module.exports = config;