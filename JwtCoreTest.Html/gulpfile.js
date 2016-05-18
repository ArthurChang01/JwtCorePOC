/// <binding AfterBuild='compile:js' />
"use strict";

var gulp = require('gulp');
var webpack = require('webpack');
var utility = require('gulp-util');
var webpackConfig = require('./webpack.config.js');

var paths = {
    webroot: "./Scripts/"
};
paths.js = paths.webroot + "app/**/*.js";

gulp.task("compile:js", function (callback) {
    var myConfig = Object.create(webpackConfig);

    webpack(myConfig, function (err, stats) {
        if (err) throw new utility.PluginError("webpack:build", err);
        utility.log("[webpack:build]", stats.toString({
            colors: true
        }));
        callback();
    });
});

gulp.task('watch:js', ['compile:js'], function (cb) {
    gulp.watch(['./Scripts/**/**'], ['compile:js']);
});