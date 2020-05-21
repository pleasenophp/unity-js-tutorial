import { myFunction1, myFunction2 } from './MyModule';

var state = {
  name: "Alice",
  level: 2,
};

const printState = () => {
  log(`JS state name: ${state.name}; level: ${state.level}`);
};

window.getGameState = () => {
  return JSON.stringify(state);
};

window.setGameState = (stateString) => {
  state = JSON.parse(stateString);
  printState();
};

const wait = (milliseconds) => new Promise(resolve => {
  setTimeout(() => resolve(), milliseconds);
});

const asyncFunction = async () => {
  setText("This is a text");
  await wait(5000);
  setText("And now it's changed after await");
};

asyncFunction();

