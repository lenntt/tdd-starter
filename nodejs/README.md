# Prerequisites
- NodeJS
- A shell: such as bash, zsh or PowerShell
- (optional)`nodemon` (`npm install -g nodemon`)

# Setup
```
npm install
```

# Run tests
```
../tddiscipline/runner.sh "npm test"
```
or as a watcher, which will run tests on file changes:
```
nodemon -e js --exec '../tddiscipline/runner.sh "npm test"'
```
