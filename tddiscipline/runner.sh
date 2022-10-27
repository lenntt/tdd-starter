#!/bin/bash

# The first argument should be the command to run
cmd=$1
$cmd

exit_code=$?

echo "Exit code: $exit_code"

result_char='🟡'

if [ ${exit_code} == 0 ]
then
  result_char='🟢'
else if [ ${exit_code} == 1 ]
  then
    result_char='🔴'
  fi
fi

echo -e "[$result_char] $(cat .tddiscipline.results.txt;)"
# Prepend and write to file
echo -e "$result_char$(cat .tddiscipline.results.txt;)" > .tddiscipline.results.txt
