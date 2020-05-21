import { myFunction1, myFunction2 } from './MyModule';

var state = {
  name: "Alice",
  level: 2,
};

const printState = () => {
  log(`JS state name: ${state.name}; level: ${state.level}`);
};
printState();

window.getGameState = () => {
  return JSON.stringify(state);
};

window.setGameState = (stateString) => {
  state = JSON.parse(stateString);
  printState();
};
