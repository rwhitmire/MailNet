import { RECEIVE_MESSAGE } from '../actions/messages'
import { fromJS } from 'immutable'

const initialState = fromJS([])

export default function(state = initialState, action) {
  switch(action.type) {
    case RECEIVE_MESSAGE:
      return state.push(fromJS(action.message))
    default:
      return state
  }
}
