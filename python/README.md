# Prerequisites
- Python 3.6 or higher (+ pip)
- A shell: such as bash, zsh or PowerShell
- NodeJS
    - (optional) `nodemon` (`npm install -g nodemon`)

# Setup
```
pip install -r requirements.txt
```

# Run tests via TDDiscipline

```
node ../tddiscipline/index.js pytest
```
or as a watcher, which will run tests on file changes:
```
nodemon -e py --exec "node ../tddiscipline/index.js pytest"
```
