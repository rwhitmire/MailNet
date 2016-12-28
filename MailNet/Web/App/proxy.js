import $ from 'jquery'
import 'signalr'
import store from './store'
import { receiveMessage } from './actions/messages'

const proxy = {
  connect() {
    const connection = $.hubConnection()
    const mailHubProxy = connection.createHubProxy('mailHub')

    mailHubProxy.on('receiveMessage', () => {
      store.dispatch(receiveMessage({}))
    })

    return connection.start()
      .done(() => { console.log('Now connected, connection id:', connection.id) })
      .fail(() => { console.log('Could not connect') })
  }
}

export default proxy
