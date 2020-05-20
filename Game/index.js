import { myFunction1, myFunction2 } from './MyModule';

const hello = () => {
  return "Hello from JS ES6 file!";
};

log(hello());
log(myFunction1());
log(myFunction2());

window.thisIsGlobalVariable = 108;

log("I can see global variable: "+thisIsGlobalVariable);
