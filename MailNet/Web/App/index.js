import React from 'react'
import ReactDOM from 'react-dom'
import { Provider, connect } from 'react-redux'
import proxy from './proxy'
import store from './store'

proxy.connect()

const Foo = props => {
  return <div>{props.messages.length || 0}</div>
}

const mapStateToProps = state => {
  return {
    messages: state.messages.toJS()
  }
}

const ConnectedFoo = connect(mapStateToProps)(Foo)

const root = (
  <Provider store={store}>
    <ConnectedFoo />
  </Provider>
)

ReactDOM.render(root, document.getElementById('app'))
