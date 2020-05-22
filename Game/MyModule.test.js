import { asyncFunction } from './MyModule';

test('sets initial text', () => {
  // arrange
  window.setText = jest.fn();

  // act
  asyncFunction();
  
  // assert
  expect(setText.mock.calls[0][0]).toBe("This is a text");
});

test('sets second text', async () => {
  // arrange
  window.setText = jest.fn();

  // act
  await asyncFunction();
  
  // assert
  expect(setText.mock.calls[1][0]).toBe("And now it's changed after await");
});



