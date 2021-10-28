export const IdentityServerUrl = 'https://localhost:44353'
export const AppBaseUrl='https://localhost:3000'
export const ResBaseUrl='https://localhost:44324'
export const settings ={
    authority:`${IdentityServerUrl}`,
    client_id:'client_react_id',
    response_type:'code',
    scope:'openid profile TicketShopAPI',
    redirect_uri:`${AppBaseUrl}/callback`,
    silent_redirect_uri:`${AppBaseUrl}`,
    post_logout_redirect_uri:`${AppBaseUrl}`
}