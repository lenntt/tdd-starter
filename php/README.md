# Prerequisites
- PHP
- NodeJS
    - (optional) `nodemon` (`npm install -g nodemon`)

# Run tests via TDDiscipline

```
node ../tddiscipline/index.js php ./vendor/bin/phpunit-9.5.phar ResultTest.php
```
or as a watcher, which will run tests on file changes:
```
nodemon -e php --exec "node ../tddiscipline/index.js php ./vendor/bin/phpunit-9.5.phar ResultTest.php"
```
