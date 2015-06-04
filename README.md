IIS URL Rewrite Generator
========================

Converts a CSV of source + destination URLs and generates an IIS UrlRewrite map for placement inside of a web.config.

Prerequisites
-------------
* IIS
* IIS UrlRewrite Module 2.0
* Configured rewrite rule that uses a redirect map

Generating the rewrite map
--------------------------

The console application takes two arguments: a path to a CSV file and the name of the rewrite map.


    redirectmapgenerator.exe "redirects.csv" "Website Cutover"

Inserting the rewrite map into a web.config
-------------------------------------------
The output file will be a properly structured rewrite map within a `web.config`. Copy and paste the `<rewriteMap>` entry to your existing web.config.