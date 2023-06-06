# Prerequisites
- NodeJS
- A shell: such as bash, zsh or PowerShell
- (optional)`nodemon` (`npm install -g nodemon`)

# Setup
```
npm install
```

# Run tests via TDDiscipline

```
node ../tddiscipline/index.js npm test
```
or as a watcher, which will run tests on file changes:
```
nodemon -e ts --exec "node ../tddiscipline/index.js npm test"
```
