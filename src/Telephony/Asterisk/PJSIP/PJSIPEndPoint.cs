using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPEndPoint
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        /// <summary>
        ///     Allow support for RFC3262 provisional ACK tags
        /// </summary>
        [JsonPropertyName("100rel")]
        [Column("100rel")]
        public virtual string? _100rel { get; set; }

        /// <summary>
        ///     Condense MWI notifications into a single NOTIFY.
        /// </summary>
        [JsonPropertyName("aggregate_mwi")]
        [Column("aggregate_mwi"), Display(Name = "aggregate_mwi")]
        public virtual string? aggregate_mwi { get; set; }

        /// <summary>
        ///     Media Codec(s) to disallow
        /// </summary>
        [JsonPropertyName("disallow")]
        [Column("disallow")]
        public virtual string? disallow { get; set; }

        /// <summary>
        ///     Media Codec(s) to allow.
        /// </summary>
        [JsonPropertyName("allow")]
        [Column("allow")]
        public virtual string? allow { get; set; }

        /// <summary>
        ///     Codec negotiation prefs for incoming offers
        /// </summary>
        [JsonPropertyName("codec_prefs_incoming_offer")]
        [Column("codec_prefs_incoming_offer")]
        [NotMapped]
        public virtual string? codec_prefs_incoming_offer { get; set; }

        /// <summary>
        ///     Codec negotiation prefs for outgoing offers.
        /// </summary>
        [JsonPropertyName("codec_prefs_outgoing_offer")]
        [Column("codec_prefs_outgoing_offer")]
        [NotMapped]
        public virtual string? codec_prefs_outgoing_offer { get; set; }

        /// <summary>
        ///     Codec negotiation prefs for incoming answers.
        /// </summary>
        [JsonPropertyName("codec_prefs_incoming_answer")]
        [Column("codec_prefs_incoming_answer")]
        [NotMapped]
        public virtual string? codec_prefs_incoming_answer { get; set; }

        /// <summary>
        ///     Codec negotiation prefs for outgoing answers.
        /// </summary>
        [JsonPropertyName("codec_prefs_outgoing_answer")]
        [Column("codec_prefs_outgoing_answer")]
        [NotMapped]
        public virtual string? codec_prefs_outgoing_answer { get; set; }

        /// <summary>
        ///     Enable RFC3578 overlap dialing support.
        /// </summary>
        [JsonPropertyName("allow_overlap")]
        [Column("allow_overlap")]
        public virtual string? allow_overlap { get; set; }

        /// <summary>
        ///     AoR(s) to be used with the endpoint
        /// </summary>
        [JsonPropertyName("aors")]
        [Column("aors")]
        public virtual string? aors { get; set; }

        /// <summary>
        ///     Authentication Object(s) associated with the endpoint
        /// </summary>
        [JsonPropertyName("auth")]
        [Column("auth")]
        public virtual string? auth { get; set; }

        /// <summary>
        ///     CallerID information for the endpoint
        /// </summary>
        [JsonPropertyName("callerid")]
        [Column("callerid")]
        public virtual string? callerid { get; set; }

        /// <summary>
        ///     Default privacy level
        /// </summary>
        [JsonPropertyName("callerid_privacy")]
        [Column("callerid_privacy")]
        public virtual string? callerid_privacy { get; set; }

        /// <summary>
        ///     Internal id_tag for the endpoint
        /// </summary>
        [JsonPropertyName("callerid_tag")]
        [Column("callerid_tag")]
        public virtual string? callerid_tag { get; set; }

        /// <summary>
        ///     Dialplan context for inbound sessions
        /// </summary>
        [JsonPropertyName("context")]
        [Column("context")]
        public virtual string? context { get; set; }

        /// <summary>
        ///     Mitigation of direct media (re)INVITE glare
        /// </summary>
        [JsonPropertyName("direct_media_glare_mitigation")]
        [Column("direct_media_glare_mitigation")]
        public virtual string? direct_media_glare_mitigation { get; set; }

        /// <summary>
        ///     Direct Media method type
        /// </summary>
        [JsonPropertyName("direct_media_method")]
        [Column("direct_media_method")]
        public virtual string? direct_media_method { get; set; }

        /// <summary>
        ///     Accept Connected Line updates from this endpoint
        /// </summary>
        [JsonPropertyName("trust_connected_line")]
        [Column("trust_connected_line")]
        public virtual string? trust_connected_line { get; set; }

        /// <summary>
        ///     Send Connected Line updates to this endpoint
        /// </summary>
        [JsonPropertyName("send_connected_line")]
        [Column("send_connected_line")]
        public virtual string? send_connected_line { get; set; }

        /// <summary>
        ///     Connected line method type
        /// </summary>
        [JsonPropertyName("connected_line_method")]
        [Column("connected_line_method")]
        public virtual string? connected_line_method { get; set; }

        /// <summary>
        ///     Determines whether media may flow directly between endpoints
        /// </summary>
        [JsonPropertyName("direct_media")]
        [Column("direct_media")]
        public virtual string? direct_media { get; set; }

        /// <summary>
        ///     Disable direct media session refreshes when NAT obstructs the media session
        /// </summary>
        [JsonPropertyName("disable_direct_media_on_nat")]
        [Column("disable_direct_media_on_nat")]
        public virtual string? disable_direct_media_on_nat { get; set; }

        /// <summary>
        ///     DTMF mode
        /// </summary>
        [JsonPropertyName("dtmf_mode")]
        [Column("dtmf_mode")]
        public virtual string? dtmf_mode { get; set; }

        /// <summary>
        ///     IP address used in SDP for media handling
        /// </summary>
        [JsonPropertyName("media_address")]
        [Column("media_address")]
        public virtual string? media_address { get; set; }

        /// <summary>
        ///     Bind the RTP instance to the media_address
        /// </summary>
        [JsonPropertyName("bind_rtp_to_media_address")]
        [Column("bind_rtp_to_media_address")]
        public virtual string? bind_rtp_to_media_address { get; set; }

        /// <summary>
        ///     Force use of return port
        /// </summary>
        [JsonPropertyName("force_rport")]
        [Column("force_rport")]
        public virtual string? force_rport { get; set; }

        /// <summary>
        ///     Enable the ICE mechanism to help traverse NAT
        /// </summary>
        [JsonPropertyName("ice_support")]
        [Column("ice_support")]
        public virtual string? ice_support { get; set; }

        /// <summary>
        ///     Way(s) for the endpoint to be identified
        /// </summary>
        [JsonPropertyName("identify_by")]
        [Column("identify_by")]
        public virtual string? identify_by { get; set; }

        /// <summary>
        ///     How redirects received from an endpoint are handled
        /// </summary>
        [JsonPropertyName("redirect_method")]
        [Column("redirect_method")]
        public virtual string? redirect_method { get; set; }

        /// <summary>
        ///     NOTIFY the endpoint when state changes for any of the specified mailboxes
        /// </summary>
        [JsonPropertyName("mailboxes")]
        [Column("mailboxes")]
        public virtual string? mailboxes { get; set; }

        /// <summary>
        ///     An MWI subscribe will replace sending unsolicited NOTIFYs
        /// </summary>
        [JsonPropertyName("mwi_subscribe_replaces_unsolicited")]
        [Column("mwi_subscribe_replaces_unsolicited")]
        public virtual string? mwi_subscribe_replaces_unsolicited { get; set; }

        /// <summary>
        ///     The voicemail extension to send in the NOTIFY Message-Account header
        /// </summary>
        [JsonPropertyName("voicemail_extension")]
        [Column("voicemail_extension")]
        public virtual string? voicemail_extension { get; set; }

        /// <summary>
        ///     Default Music On Hold class
        /// </summary>
        [JsonPropertyName("moh_suggest")]
        [Column("moh_suggest")]
        public virtual string? moh_suggest { get; set; }

        /// <summary>
        ///     Authentication object(s) used for outbound requests
        /// </summary>
        [JsonPropertyName("outbound_auth")]
        [Column("outbound_auth")]
        public virtual string? outbound_auth { get; set; }

        /// <summary>
        ///     Full SIP URI of the outbound proxy used to send requests
        /// </summary>
        [JsonPropertyName("outbound_proxy")]
        [Column("outbound_proxy")]
        public virtual string? outbound_proxy { get; set; }

        /// <summary>
        ///     Allow Contact header to be rewritten with the source IP address-port
        /// </summary>
        [JsonPropertyName("rewrite_contact")]
        [Column("rewrite_contact")]
        public virtual string? rewrite_contact { get; set; }

        /// <summary>
        ///     Allow use of IPv6 for RTP traffic
        /// </summary>
        [JsonPropertyName("rtp_ipv6")]
        [Column("rtp_ipv6")]
        public virtual string? rtp_ipv6 { get; set; }

        /// <summary>
        ///     Send the Diversion header, conveying the diversion information to the called user agent
        /// </summary>
        [JsonPropertyName("send_diversion")]
        [Column("send_diversion")]
        public virtual string? send_diversion { get; set; }

        /// <summary>
        ///     Enforce that RTP must be symmetric
        /// </summary>
        [JsonPropertyName("rtp_symmetric")]
        [Column("rtp_symmetric")]
        public virtual string? rtp_symmetric { get; set; }

        /// <summary>
        ///     Send the History-Info header, conveying the diversion information to the called and calling user agents
        /// </summary>
        [JsonPropertyName("send_history_info")]
        [Column("send_history_info")]
        [NotMapped]
        public virtual string? send_history_info { get; set; }

        /// <summary>
        ///     Send the P-Asserted-Identity header
        /// </summary>
        [JsonPropertyName("send_pai")]
        [Column("send_pai")]
        public virtual string? send_pai { get; set; }

        /// <summary>
        ///     Send the Remote-Party-ID header
        /// </summary>
        [JsonPropertyName("send_rpid")]
        [Column("send_rpid")]
        public virtual string? send_rpid { get; set; }

        /// <summary>
        ///     Immediately send connected line updates on unanswered incoming calls
        /// </summary>
        [JsonPropertyName("rpid_immediate")]
        [Column("rpid_immediate")]
        public virtual string? rpid_immediate { get; set; }

        /// <summary>
        ///     An accountcode to set automatically on any channels created for this endpoint
        /// </summary>
        [JsonPropertyName("accountcode")]
        [Column("accountcode")]
        public virtual string? accountcode { get; set; }

        /// <summary>
        ///     Domain to user in From header for requests to this endpoint
        /// </summary>
        [JsonPropertyName("from_domain")]
        [Column("from_domain")]
        public virtual string? from_domain { get; set; }

        /// <summary>
        ///     String used for the SDP session (s=) line
        /// </summary>
        [JsonPropertyName("sdp_session")]
        [Column("sdp_session")]
        public virtual string? sdp_session { get; set; }

        /// <summary>
        ///     Defaults and enables some options that are relevant to WebRTC
        /// </summary>
        [JsonPropertyName("webrtc")]
        [Column("webrtc")]
        public virtual bool? webrtc { get; set; }

        /*
        timers_min_se				Minimum session timers expiration period
        timers				Session timers for SIP packets
        timers_sess_expires				Maximum session timer expiration period
        transport				Explicit transport configuration to use
        trust_id_inbound				Accept identification information received from this endpoint
        trust_id_outbound				Send private identification details to the endpoint.
        use_ptime				Use Endpoint's requested packetization interval
        use_avpf				Determines whether res_pjsip will use and enforce usage of AVPF for this endpoint.
        force_avp				Determines whether res_pjsip will use and enforce usage of AVP, regardless of the RTP profile in use for this endpoint.
        media_use_received_transport				Determines whether res_pjsip will use the media transport received in the offer SDP in the corresponding answer SDP.
        media_encryption				Determines whether res_pjsip will use and enforce usage of media encryption for this endpoint.
        media_encryption_optimistic				Determines whether encryption should be used if possible but does not terminate the session if not achieved.
        g726_non_standard				Force g.726 to use AAL2 packing order when negotiating g.726 audio
        inband_progress				Determines whether chan_pjsip will indicate ringing using inband progress.
        call_group				The numeric pickup groups for a channel.
        pickup_group				The numeric pickup groups that a channel can pickup.
        named_call_group				The named pickup groups for a channel.
        named_pickup_group				The named pickup groups that a channel can pickup.
        device_state_busy_at				The number of in-use channels which will cause busy to be returned as device state
        t38_udptl				Whether T.38 UDPTL support is enabled or not
        t38_udptl_ec				T.38 UDPTL error correction method
        t38_udptl_maxdatagram				T.38 UDPTL maximum datagram size
        fax_detect				Whether CNG tone detection is enabled
        fax_detect_timeout				How long into a call before fax_detect is disabled for the call
        t38_udptl_nat				Whether NAT support is enabled on UDPTL sessions
        t38_udptl_ipv6				Whether IPv6 is used for UDPTL Sessions
        t38_bind_udptl_to_media_address				Bind the UDPTL instance to the media_adress
        tone_zone				Set which country's indications to use for channels created for this endpoint.
        language				Set the default language to use for channels created for this endpoint.
        one_touch_recording				Determines whether one-touch recording is allowed for this endpoint.
        record_on_feature				The feature to enact when one-touch recording is turned on.
        record_off_feature				The feature to enact when one-touch recording is turned off.
        rtp_engine				Name of the RTP engine to use for channels created for this endpoint
        allow_transfer				Determines whether SIP REFER transfers are allowed for this endpoint
        user_eq_phone				Determines whether a user=phone parameter is placed into the request URI if the user is determined to be a phone number
        moh_passthrough				Determines whether hold and unhold will be passed through using re-INVITEs with recvonly and sendrecv to the remote side
        sdp_owner				String placed as the username portion of an SDP origin (o=) line.
        
        tos_audio				DSCP TOS bits for audio streams
        tos_video				DSCP TOS bits for video streams
        cos_audio				Priority for audio streams
        cos_video				Priority for video streams
        allow_subscribe				Determines if endpoint is allowed to initiate subscriptions with Asterisk.
        sub_min_expiry				The minimum allowed expiry time for subscriptions initiated by the endpoint.
        from_user				Username to use in From header for requests to this endpoint.
        mwi_from_user				Username to use in From header for unsolicited MWI NOTIFYs to this endpoint.
        dtls_verify				Verify that the provided peer certificate is valid
        dtls_rekey				Interval at which to renegotiate the TLS session and rekey the SRTP session
        dtls_auto_generate_cert				Whether or not to automatically generate an ephemeral X.509 certificate
        dtls_cert_file				Path to certificate file to present to peer
        dtls_private_key				Path to private key for certificate file
        dtls_cipher				Cipher to use for DTLS negotiation
        dtls_ca_file				Path to certificate authority certificate
        dtls_ca_path				Path to a directory containing certificate authority certificates
        dtls_setup				Whether we are willing to accept connections, connect to the other party, or both.
        dtls_fingerprint				Type of hash to use for the DTLS fingerprint in the SDP.
        srtp_tag_32				Determines whether 32 byte tags should be used instead of 80 byte tags.
        set_var				Variable set on a channel involving the endpoint.
        message_context				Context to route incoming MESSAGE requests to.
        preferred_codec_only				Respond to a SIP invite with the single most preferred codec (DEPRECATED)
        incoming_call_offer_pref				Preferences for selecting codecs for an incoming call.
        outgoing_call_offer_pref				Preferences for selecting codecs for an outgoing call.
        rtp_keepalive				Number of seconds between RTP comfort noise keepalive packets.
        rtp_timeout				Maximum number of seconds without receiving RTP (while off hold) before terminating call.
        rtp_timeout_hold				Maximum number of seconds without receiving RTP (while on hold) before terminating call.
        acl				List of IP ACL section names in acl.conf
        deny				List of IP addresses to deny access from
        permit				List of IP addresses to permit access from
        contact_acl				List of Contact ACL section names in acl.conf
        contact_deny				List of Contact header addresses to deny
        contact_permit				List of Contact header addresses to permit
        subscribe_context				Context for incoming MESSAGE requests.
        contact_user				Force the user on the outgoing Contact header to this value.
        asymmetric_rtp_codec				Allow the sending and receiving RTP codec to differ
        rtcp_mux				Enable RFC 5761 RTCP multiplexing on the RTP port
        refer_blind_progress				Whether to notifies all the progress details on blind transfer
        notify_early_inuse_ringing				Whether to notifies dialog-info 'early' on InUse&Ringing state
        max_audio_streams				The maximum number of allowed audio streams for the endpoint
        max_video_streams				The maximum number of allowed video streams for the endpoint
        bundle				Enable RTP bundling
        incoming_mwi_mailbox				Mailbox name to use when incoming MWI NOTIFYs are received
        follow_early_media_fork				Follow SDP forked media when To tag is different
        accept_multiple_sdp_answers				Accept multiple SDP answers on non-100rel responses
        suppress_q850_reason_headers				Suppress Q.850 Reason headers for this endpoint
        ignore_183_without_sdp				Do not forward 183 when it doesn't contain SDP
        stir_shaken				Enable STIR/SHAKEN support on this endpoint
        stir_shaken_profile				STIR/SHAKEN profile containing additional configuration options
        allow_unauthenticated_options				Skip authentication when receiving OPTIONS requests
        geoloc_incoming_call_profile				Geolocation profile to apply to incoming calls
        geoloc_outgoing_call_profile				Geolocation profile to apply to outgoing calls
        */
    }
}
