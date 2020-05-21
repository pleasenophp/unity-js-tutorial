import { myFunction1, myFunction2 } from './MyModule';

const state = {
  name: "Alice",
  level: 2,
};

const printState = () => {
  log(`JS state name: ${state.name}; level: ${state.level}`);
};
printState();


