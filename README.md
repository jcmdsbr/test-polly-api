# Test Polly API :sunglasses:

Project aimed at testing Polly library calls

## Give a Star! :star:

If you liked the project, please give a star ;)

## You need some of the fallowing tools :exclamation:

-  .NET6

## Description :books:

The project contains 3 APIs:

[GET] -> "/sleep" : returns status code 200 of 5 seconds, it is possible to customize by informing in the query string the parameter time "/sleep?time=10"

[GET] -> "/fail" : returns status code 400

[GET] -> "/intermittent" : can return 200 or 400 randomly

